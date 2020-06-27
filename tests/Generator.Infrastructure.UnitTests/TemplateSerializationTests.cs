using System.Threading.Tasks;
using Generator.Domain.Entities;
using Generator.Domain.Persistence;
using Generator.Infrastructure.UnitTests.Utility;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
	public class TemplateSerializationTests
	{
		[Fact]
		public async Task FullTemplate()
		{
			var template = new Template();
			var serialized = JsonConvert.SerializeObject(template, GetDefaultSettings());
			serialized.ShouldNotBeNull();
		}

		[Fact]
		public async Task ParameterSymbol()
		{
			var symbol = new ParameterSymbol();
			symbol.DataType = SymbolDataType.Hex;
			symbol.DefaultValue = "defaultValue";
			symbol.Description = "description";
			symbol.Replaces = "replaces";
			symbol.Type = SymbolType.Computed;

			var serialized = JsonConvert.SerializeObject(symbol, GetDefaultSettings());
			var deserialized = JsonConvert.DeserializeObject<ParameterSymbol>(serialized);
			symbol.DataType.ShouldBe(deserialized.DataType);
			symbol.Type.ShouldBe(deserialized.Type);
			symbol.Description.ShouldBe(deserialized.Description);
			symbol.DefaultValue.ShouldBe(deserialized.DefaultValue);
			symbol.Replaces.ShouldBe(deserialized.Replaces);

			var testFile = await GetJsonFile<ParameterSymbol>("parameterSymbol.json", "Serialization");
			testFile.DataType.ShouldBe(deserialized.DataType);
			testFile.Type.ShouldBe(deserialized.Type);
			testFile.Description.ShouldBe(deserialized.Description);
			testFile.DefaultValue.ShouldBe(deserialized.DefaultValue);
			testFile.Replaces.ShouldBe(deserialized.Replaces);
		}

		private static async Task<T> GetJsonFile<T>(string file, params string[] paths)
		{
			var helper = GetManifestFileHelper();
			using var reader = helper.GetStreamReader(file, paths);
			var content = await reader.ReadToEndAsync();
			return JsonConvert.DeserializeObject<T>(content);
		}

		private static ManifestFileHelper GetManifestFileHelper()
		{
			return new ManifestFileHelper("Generator.Infrastructure.UnitTests.ExpectedOutput", typeof(ManifestFileHelper).Assembly);
		}

		private static JsonSerializerSettings GetDefaultSettings()
		{
			return SerializationHelper.GetSettings();
		}
	}
}