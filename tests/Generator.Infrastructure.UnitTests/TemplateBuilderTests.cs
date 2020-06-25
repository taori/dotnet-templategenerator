using Generator.Domain.Entities;
using Generator.Domain.Features.Template;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class TemplateBuilderTests
    {
        [Fact]
        public void Author()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithAuthor("test1").ToTemplate().Author.ShouldBe("test1");
            builder.WithAuthor("test2").ToTemplate().Author.ShouldBe("test2");
        }
        
        [Fact]
        public void Description()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithDescription("test1").ToTemplate().Description.ShouldBe("test1");
            builder.WithDescription("test2").ToTemplate().Description.ShouldBe("test2");
        }
        
        [Fact]
        public void Identity()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithIdentity("test1").ToTemplate().Identity.ShouldBe("test1");
            builder.WithIdentity("test2").ToTemplate().Identity.ShouldBe("test2");
        }
        
        [Fact]
        public void Name()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithName("test1").ToTemplate().Name.ShouldBe("test1");
            builder.WithName("test2").ToTemplate().Name.ShouldBe("test2");
        }
        
        [Fact]
        public void Schema()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithSchema("test1").ToTemplate().Schema.ShouldBe("test1");
            builder.WithSchema("test2").ToTemplate().Schema.ShouldBe("test2");
        }
        
        [Fact]
        public void DefaultName()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithDefaultName("test1").ToTemplate().DefaultName.ShouldBe("test1");
            builder.WithDefaultName("test2").ToTemplate().DefaultName.ShouldBe("test2");
        }
        
        [Fact]
        public void ShortName()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithShortName("test1").ToTemplate().ShortName.ShouldBe("test1");
            builder.WithShortName("test2").ToTemplate().ShortName.ShouldBe("test2");
        }
        
        [Fact]
        public void SourceName()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithSourceName("test1").ToTemplate().SourceName.ShouldBe("test1");
            builder.WithSourceName("test2").ToTemplate().SourceName.ShouldBe("test2");
        }
        
        [Fact]
        public void GroupIdentity()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithGroupIdentity("test1").ToTemplate().GroupIdentity.ShouldBe("test1");
            builder.WithGroupIdentity("test2").ToTemplate().GroupIdentity.ShouldBe("test2");
        }
        
        [Fact]
        public void Precedence()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithPrecedence(1).ToTemplate().Precedence.ShouldBe(1);
            builder.WithPrecedence(2).ToTemplate().Precedence.ShouldBe(2);
        }
        
        [Fact]
        public void PlaceholderFileName()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithPlaceholderFileName("test1").ToTemplate().PlaceholderFileName.ShouldBe("test1");
            builder.WithPlaceholderFileName("test2").ToTemplate().PlaceholderFileName.ShouldBe("test2");
        }
        
        [Fact]
        public void PreferNameDirectory()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithPreferNameDirectory(true).ToTemplate().PreferNameDirectory.ShouldBeTrue();
            builder.WithPreferNameDirectory(false).ToTemplate().PreferNameDirectory.ShouldBeFalse();
        }
        
        [Fact]
        public void ThirdPartyNotices()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithThirdPartyNotices("test1").ToTemplate().ThirdPartyNotices.ShouldBe("test1");
            builder.WithThirdPartyNotices("test2").ToTemplate().ThirdPartyNotices.ShouldBe("test2");
        }
        
        [Fact]
        public void CodeLanguage()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithCodeLanguage("test1").ToTemplate().Tags.Language.ShouldBe("test1");
            builder.WithCodeLanguage("test2").ToTemplate().Tags.Language.ShouldBe("test2");
        }
        
        [Fact]
        public void TemplateType()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithTemplateType("test1").ToTemplate().Tags.Type.ShouldBe("test1");
            builder.WithTemplateType("test2").ToTemplate().Tags.Type.ShouldBe("test2");
        }
        
        [Fact]
        public void Classifications()
        {
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithClassification("test1").ToTemplate().Classifications.ShouldContain("test1");
            var template = builder.WithClassification("test2").ToTemplate();
            template.Classifications.ShouldContain("test1");
            template.Classifications.ShouldContain("test2");
        }
        
        [Fact]
        public void Guid()
        {
            var values = new[] {System.Guid.NewGuid(), System.Guid.NewGuid(), };
            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithGuid(values[0]).ToTemplate().Guids.ShouldContain(values[0]);
            var template = builder.WithGuid(values[1]).ToTemplate();
            template.Guids.ShouldContain(values[0]);
            template.Guids.ShouldContain(values[1]);
        }
        
        [Fact]
        public void Sources()
        {
            var values = new[]
            {
                new SourceValue(), 
                new SourceValue(), 
            };

            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithSource(values[0]).ToTemplate().Sources.ShouldContain(values[0]);
            var template = builder.WithSource(values[1]).ToTemplate();
            template.Sources.ShouldContain(values[0]);
            template.Sources.ShouldContain(values[1]);
        }
        
        [Fact]
        public void Symbols()
        {
            var values = new BaseSymbol[]
            {
                new ParameterSymbol(), 
                new ParameterSymbol(), 
            };

            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithSymbol("a", values[0]).ToTemplate().Symbols.Values.ShouldContain(values[0]);
            var template = builder.WithSymbol("b", values[1]).ToTemplate();
            template.Symbols.Values.ShouldContain(values[0]);
            template.Symbols.Values.ShouldContain(values[1]);
        }
        
        [Fact]
        public void SymbolsOverrideCheck()
        {
            var values = new BaseSymbol[]
            {
                new ParameterSymbol(), 
                new ParameterSymbol(), 
            };

            var builder = TemplateBuilder.FromContainer(new TemplateContainer());
            builder.WithSymbol("a", values[0]).ToTemplate().Symbols.Values.ShouldContain(values[0]);
            builder.WithSymbol("a", values[1]).ToTemplate().Symbols.Values.ShouldContain(values[1]);
            var symbols = builder.ToTemplate().Symbols;
            symbols.Count.ShouldBe(1);
            symbols.Keys.ShouldContain("a");
            symbols.Values.ShouldContain(values[1]);
        }
    }
}