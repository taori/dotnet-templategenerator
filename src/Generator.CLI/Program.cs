using System;
using System.Reflection;
using System.Threading.Tasks;
using CommandDotNet;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using CommandDotNet.NameCasing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace Generator.CLI
{
	class Program
	{
		private static readonly ILogger Log = LogManager.GetLogger(nameof(Program));

		static async Task<int> Main(string[] args)
		{
			try
			{
				Log.Info("Running application with parameters {@arguments}", args);
				var runner = new AppRunner<ConsoleApplication>();
				ConfigureApplication(runner);
				var exitCode = await runner.RunAsync(args);
				Log.Info("Application exited with error code {exitCode}.", exitCode);
				return exitCode;
			}
			catch (Exception e)
			{
				Log.Error(e, "Application terminated in an unexpected way.");
				return -1;
			}
			finally
			{
				LogManager.Flush(TimeSpan.FromSeconds(2));
#if DEBUG
				Console.ReadKey();
#endif
			}
		}

		private static void ConfigureApplication(AppRunner<ConsoleApplication> runner)
		{
			runner.Configure(configuration =>
			{
				configuration.UseParameterResolver(context => context.DependencyResolver);
			});

			runner
				.UseNameCasing(Case.LowerCase, true)
				.UseCommandLogger()
				.UseTypoSuggestions()
				.UseMicrosoftDependencyInjection(BuildServiceProvider());
		}

		private static ServiceProvider BuildServiceProvider()
		{
			var serviceCollection = new ServiceCollection();
			var startup = new Startup();
			startup.Configure(serviceCollection);
			return serviceCollection.BuildServiceProvider();
		}
	}
}
