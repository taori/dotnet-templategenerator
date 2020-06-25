using System;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using CommandDotNet;
using Generator.Domain.Features;
using Generator.Domain.Features.Template;
using Generator.Domain.Features.Workspace;
using Generator.Domain.FileSystem;
using Generator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using ILogger = NLog.ILogger;

namespace Generator.CLI
{
	public class Startup
	{
		private static readonly ILogger Log = LogManager.GetLogger(nameof(Startup));

		public void Configure(ServiceCollection serviceCollection)
		{
			RegisterCommonServices(serviceCollection);
			RegisterApplicationParts(serviceCollection);
		}

		private static void RegisterApplicationParts(ServiceCollection serviceCollection)
		{
			Log.Debug("Registering application part types.");
			var subCommandTypes = Assembly
				.GetExecutingAssembly()
				.ExportedTypes
				.Where(d => d.GetCustomAttribute<SubCommandAttribute>() != null);

			foreach (var subCommandType in subCommandTypes)
			{
				Log.Debug("Registering subcommand type {type}", subCommandType);
				serviceCollection.AddScoped(subCommandType);
			}
		}

		private static void RegisterCommonServices(ServiceCollection serviceCollection)
		{
			Log.Debug("Registering common services.");
			serviceCollection.AddScoped(typeof(ILoggerFactory), typeof(NLogLoggerFactory));
			serviceCollection.AddScoped(typeof(ILogger<>), typeof(Logger<>));
			serviceCollection.AddScoped<IWorkspaceManager, WorkspaceManager>();
			serviceCollection.AddScoped<ITemplateManager, TemplateManager>();
			serviceCollection.AddScoped<IRoamingPathService, RoamingPathService>();
			serviceCollection.AddScoped<IFileSystem, FileSystem>();
		}
	}
}