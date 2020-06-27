using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Generator.Domain.Features.Workspace;
using Generator.Domain.Resources;
using Generator.Domain.Utility;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class WorkspaceManagerTests
    {
        [Fact]
        public async Task Create()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            var workspace = await manager.CreateAsync("test");
            manager.Exists("test").ShouldBeTrue();
            manager.Exists("test2").ShouldBeFalse();
            workspace.Directory.ShouldEndWith("test");
        }
        
        [Fact]
        public async Task DoubleCreateShouldThrow()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            await manager.CreateAsync("test");
            manager.Exists("test").ShouldBeTrue();
            var ex = await Assert.ThrowsAsync<WorkspaceAlreadyExistsException>(async() => await manager.CreateAsync("test"));
            ex.ExitCode.ShouldBe(Constants.WellKnownErrorCodes.WorkspaceAlreadyExists);
            ex.WorkspaceName.ShouldBe("test");
        }
        
        [Fact]
        public async Task GetNoExists()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            var ex = await Assert.ThrowsAsync<WorkspaceNotFoundException>(async() => await manager.GetAsync("test"));
            ex.ExitCode.ShouldBe(Constants.WellKnownErrorCodes.WorkspaceDoesNotExist);
            ex.WorkspaceName.ShouldBe("test");
        }
        
        [Fact]
        public async Task GetWithExists()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            await manager.CreateAsync("test");
            var workspace = await manager.GetAsync("test");
            workspace.ShouldNotBeNull();
        }
        
        [Fact]
        public async Task RemoveWithExists()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            await manager.CreateAsync("test");
            var workspace = await manager.RemoveAsync("test");
            workspace.ShouldNotBeNull();
        }
        
        [Fact]
        public async Task RemoveNoExists()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            var workspace = await manager.RemoveAsync("test");
            workspace.ShouldNotBeNull();
        }
        
        [Fact]
        public void DefaultNoWorkspace()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            manager.Exists("test").ShouldBeFalse();
        }
    }
}