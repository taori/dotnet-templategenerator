using System;
using System.Threading.Tasks;
using CommandDotNet;
using Generator.Domain.Configuration;
using Generator.Domain.Features;
using Microsoft.Extensions.Logging;

namespace Generator.CLI
{
	[Command]
	public class ConsoleApplication
	{
		[SubCommand]
		public class Template
		{
			private readonly ILogger<Template> _log;
			private readonly ITemplateManager _templateManager;
			private readonly ISettingsManager _settingsManager;
			private Settings _settings;

			public Template(ILogger<Template> log, ITemplateManager templateManager, ISettingsManager settingsManager)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_templateManager = templateManager ?? throw new ArgumentNullException(nameof(templateManager));
				_settingsManager = settingsManager ?? throw new ArgumentNullException(nameof(settingsManager));
				_settings = settingsManager.LoadAsync().GetAwaiter().GetResult();
			}
			
			[Command(Name = "create")]
			public async Task Create(string id, string? workspace)
			{
				_log.LogDebug("Creating new template with name {Id}", id);
				await _templateManager.CreateAsync(id, workspace ?? _settings.CurrentWorkspace);
			}
			
			[Command(Name = "remove")]
			public async Task Remove(string id, string? workspace)
			{
				_log.LogDebug("Creating new template with name {Id}", id);
				await _templateManager.RemoveAsync(id, workspace ?? _settings.CurrentWorkspace);
			}
		}
		
		[SubCommand]
		public class Workspace
		{
			private readonly ILogger<Workspace> _log;
			private readonly IWorkspaceManager _workspaceManager;

			public Workspace(ILogger<Workspace> log, IWorkspaceManager workspaceManager)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_workspaceManager = workspaceManager ?? throw new ArgumentNullException(nameof(workspaceManager)) ;
			}


			[Command(Name = "create")]
			public async Task Create(string id)
			{
				_log.LogDebug("Creating new workspace with name {Id}", id);
				await _workspaceManager.CreateAsync(id);
			}
		}
	}
}