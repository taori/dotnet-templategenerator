using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Generator.Domain.Configuration;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class SettingsManagerTests
    {
        [Fact]
        public async Task InitializedIfNotExists()
        {
            var manager = CreateTestManager();
            var settings = await manager.LoadAsync();
            settings.ShouldNotBeNull();
            settings.CurrentWorkspace.ShouldBe("Default");
        }
        
        [Fact]
        public async Task SaveWorks()
        {
            var manager = CreateTestManager();
            await manager.SaveAsync(new Settings(){CurrentWorkspace = "Test"});
            var settings = await manager.LoadAsync();
            settings.ShouldNotBeNull();
            settings.CurrentWorkspace.ShouldBe("Test");
        }
        
        private static SettingsManager CreateTestManager()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new SettingsManager(new RoamingPathService(mockFileSystem), mockFileSystem);
            return manager;
        }
    }
}