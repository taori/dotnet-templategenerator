using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Generator.CLI.Component.Parser;
using Generator.CLI.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Generator.CLI
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			var builder = new CommandLineBuilder()
				.UseHost(host => { host.ConfigureServices((context, services) =>
				{
					services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
					services.AddTransient(typeof(ILoggerFactory), typeof(LoggerFactory));
				}); })
				.UseHelp()
				.UseTypoCorrections()
				.UseAttributedCommands()
				.UseSuggestDirective();

			var parser = builder.Build();
			var parseResult = parser.Parse("Generator.CLI -v hi");
			var invoke = await parseResult.InvokeAsync();
			return invoke;

			// var attributeBuilder = new AttributeCommandLineBuilder();
			// attributeBuilder.UseMiddleware(new ServiceInjectorMiddleware());
			// var parser = attributeBuilder.Build();
			// var result = parser.Parse("test -v hi");
			//
			// var returnValue = await result.InvokeAsync(null);
			// return returnValue;
		}
	}

	public static class BuilderExtensions
	{
		public static CommandLineBuilder UseAttributedCommands(this CommandLineBuilder source)
		{
			source.UseMiddleware(async (context, next) => 
			{
				var command = new Command("test"){ new Argument()};
				command.Handler = CommandHandler.Create(Action);
				command.AddOption(new Option<string>("-v"){ Argument = new Argument<string>("-v")});
				source.AddCommand(command);
				await next.Invoke(context);
			});

			return source;
		}

		private static void Action()
		{
			throw new NotImplementedException();
		}

		private static void Test(string value)
		{
			throw new NotImplementedException();
		}
	}
}
