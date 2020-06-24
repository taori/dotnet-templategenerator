using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CommandDotNet;
using CommandDotNet.IoC.MicrosoftDependencyInjection;
using CommandDotNet.NameCasing;
using Generator.Domain.Utility;
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
#if DEBUG
			string content;
			int result;
			do
			{
				content = Environment.UserInteractive 
					? Console.ReadLine() 
					: string.Join(' ', args);

				var splitted = content.Split(' ');
				result = await RunApplication(splitted);
			} while (Environment.UserInteractive && content != "exit");

			return result;
#else
			return await RunApplication(args);
#endif
		}

		private static async Task<int> RunApplication(string[] args)
		{
			try
			{
				Log.Info("Running application with arguments: {@Arguments}, interactive: {Interactive}", 
					args, Environment.UserInteractive);
				
				var runner = new AppRunner<ConsoleApplication>();
				ConfigureApplication(runner);
				var exitCode = await runner.RunAsync(args);
				Log.Info("Application exited with error code {ExitCode}.", exitCode);
				return exitCode;
			}
			catch (WellKnownException wex)
			{
				Log.Error(wex, "Application terminated in a partially unexpected way.");
				return wex.ExitCode;
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
				// .UseTypoSuggestions()
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
