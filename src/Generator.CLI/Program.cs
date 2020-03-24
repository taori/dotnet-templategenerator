using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Reflection;
using System.Threading.Tasks;
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
					services.AddTransient(typeof(ILoggerFactory), typeof(LoggerFactory));
					services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
				}); })
				.UseDebugDirective()
				.UseHelp()
				.UseTypoCorrections()
				.UseAttributedCommands()
				.UseSuggestDirective();

			var parser = builder.Build();
			var parseResult = parser.Parse("test -b \"parameter b\" -a \"parameter a\"");
			var invoke = await parseResult.InvokeAsync();
			return invoke;
		}
	}

	public static class BuilderExtensions
	{
		public static CommandLineBuilder UseAttributedCommands(this CommandLineBuilder source)
		{
			var method = typeof(BuilderExtensions).GetMethod(nameof(Test), BindingFlags.Static | BindingFlags.NonPublic);
			var testCommand = new Command("test");
			testCommand.AddOption(new Option("-a") { Argument = new Argument("-a"){ Arity = ArgumentArity.ExactlyOne}});
			testCommand.AddOption(new Option("-b") { Argument = new Argument("-b") { Arity = ArgumentArity.ExactlyOne } });
			testCommand.Handler = CommandHandler.Create(method, null);
			source.AddCommand(testCommand);

			return source;
		}

		private static void Test(IHost host, string a, string b)
		{
			var logger = host.Services.GetRequiredService<ILogger<Program>>();
			// logger.LogDebug("just a test really");
			Console.WriteLine(a);
			Console.WriteLine(b);
		}
	}
}
