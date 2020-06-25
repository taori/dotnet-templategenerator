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
            await manager.CreateAsync("test");
            manager.Exists("test").ShouldBeTrue();
            manager.Exists("test2").ShouldBeFalse();
        }
        
        [Fact]
        public async Task DoubleCreateShouldThrow()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            await manager.CreateAsync("test");
            manager.Exists("test").ShouldBeTrue();
            var ex = await Assert.ThrowsAsync<WellKnownException>(async() => await manager.CreateAsync("test"));
            ex.ExitCode.ShouldBe(Constants.WellKnownErrorCodes.WorkspaceAlreadyExists);
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