using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Threading.Tasks;
using Generator.Domain.Entities;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class RoamingTemplateRepositoryTests
    {
        [Fact]
        public async Task ReturnsEmptyOnDefault()
        {
            var repository = CreateTestRepository();
            var templates = await repository.GetTemplatesAsync("test");
            templates.Length.ShouldBe(0);
        }
        
        [Fact]
        public async Task FileCommitWorks()
        {
            var repository = CreateTestRepository();
            var templates = (await repository.GetTemplatesAsync("test")).ToList();
            templates.Add(new TemplateContainer());
            templates.Count.ShouldBe(1); 

            await repository.SaveAsync("test", templates);
            (await repository.GetTemplatesAsync("test")).Length.ShouldBe(1);
            (await repository.GetTemplatesAsync("test2")).Length.ShouldBe(0);
        }

        private static RoamingTemplateRepository CreateTestRepository()
        {
            var mockFileSystem = new MockFileSystem();
            return new RoamingTemplateRepository(new RoamingPathService(mockFileSystem), mockFileSystem);
        }
    }
}