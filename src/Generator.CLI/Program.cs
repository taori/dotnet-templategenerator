using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Generator.CLI.Component.Parser;
using Generator.CLI.Dependencies;

namespace Generator.CLI
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			var attributeBuilder = new AttributeCommandLineBuilder();
			attributeBuilder.UseMiddleware(new ServiceInjectorMiddleware());
			var parser = attributeBuilder.Build();
			var result = parser.Parse("-v hi");

			var returnValue = await result.InvokeAsync(null);
			return returnValue;
		}
	}
}
