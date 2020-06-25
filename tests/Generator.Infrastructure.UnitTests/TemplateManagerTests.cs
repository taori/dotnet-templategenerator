using System.IO.Abstractions.TestingHelpers;
using System.Threading.Tasks;
using Generator.Domain.Features.Template;
using Generator.Domain.Features.Workspace;

namespace Generator.Infrastructure.UnitTests
{
    public class TemplateManagerTests
    {
        public async Task DoubleCreationThrows()
        {
            var mockFileSystem = new MockFileSystem();
            var manager = new TemplateManager(new WorkspaceManager(new RoamingPathService(mockFileSystem), mockFileSystem));
            await manager.CreateAsync("1", "1");
        }
    }
}