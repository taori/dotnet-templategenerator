using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Generator.Domain.Features.Template;
using Generator.Domain.Features.Workspace;
using Generator.Domain.Utility;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class TemplateManagerTests
    {
        [Fact]
        public async Task DoubleCreationThrows()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            var ex = await Assert.ThrowsAsync<TemplateAlreadyExistsException>(async () => await manager.CreateAsync("1", "1"));
            ex.TemplateId.ShouldBe("1");
        }
        
        [Fact]
        public async Task WorkspaceNoExistsGetById()
        {
            var manager = GetTestManager();
            var ex = await Assert.ThrowsAsync<WorkspaceNotFoundException>(async () => await manager.GetByIdAsync("1", "1"));
        }
        
        [Fact]
        public async Task WorkspaceNoExistsGetByWorkspace()
        {
            var manager = GetTestManager();
            var ex = await Assert.ThrowsAsync<WorkspaceNotFoundException>(async () => await manager.GetAllByWorkspaceAsync("1"));
        }
        
        [Fact]
        public async Task WorkspaceReturnMultipleByWorkspace()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            await manager.CreateAsync("2", "1");
            var workspaces = await manager.GetAllByWorkspaceAsync("1");
            workspaces.Count.ShouldBe(2);
        }
        
        [Fact]
        public async Task WorkspaceReturnSingleByWorkspace()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            await manager.CreateAsync("2", "2");
            var workspaces = await manager.GetAllByWorkspaceAsync("1");
            workspaces.Count.ShouldBe(1);
        }
        
        [Fact]
        public async Task GetWorkspaceById()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            var container = await manager.GetByIdAsync("1", "1");
            container.ShouldNotBeNull();
        }
        
        [Fact]
        public async Task GetWorkspaceByIdTemplateNotExists()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            var exception = await Assert.ThrowsAsync<TemplateNotFoundException>(
                async () => await manager.GetByIdAsync("1", "2"));
            exception.ShouldNotBeNull();
            exception.TemplateId.ShouldBe("2");
        }
        
        [Fact]
        public async Task RemoveSingle()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            await manager.RemoveAsync("1", "1");
            var workspaces = await manager.GetAllByWorkspaceAsync("1");
            workspaces.Count.ShouldBe(0);
        }
        
        [Fact]
        public async Task RemoveWorkspaceNoExists()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            var ex = Assert.ThrowsAsync<WorkspaceNotFoundException>(async() => await manager.RemoveAsync("1", "2"));
            ex.ShouldNotBeNull();
        }
        
        [Fact]
        public async Task RemoveTemplateNoExists()
        {
            var manager = GetTestManager();
            await manager.CreateAsync("1", "1");
            var ex = Assert.ThrowsAsync<TemplateNotFoundException>(async() => await manager.RemoveAsync("2", "1"));
            ex.ShouldNotBeNull();
        }

        private static TemplateManager GetTestManager()
        {
            var mockFileSystem = new MockFileSystem();
            return new TemplateManager(new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem), mockFileSystem);
        }
    }
}