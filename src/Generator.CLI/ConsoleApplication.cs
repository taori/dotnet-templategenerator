using System;
using System.Threading.Tasks;
using CommandDotNet;
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
			private readonly ITemplateCreation _templateCreation;
			private readonly ITemplateRemoval _templateRemoval;

			public Template(ILogger<Template> log, ITemplateCreation templateCreation, ITemplateRemoval templateRemoval)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_templateCreation = templateCreation ?? throw new ArgumentNullException(nameof(templateCreation));
				_templateRemoval = templateRemoval;
			}
			
			[Command(Name = "create")]
			public async Task Create(string id, string? workspace)
			{
				_log.LogDebug("Creating new template with name {Id}", id);
				await _templateCreation.CreateAsync(id, workspace);
			}
			
			[Command(Name = "remove")]
			public async Task Remove(string id, string? workspace)
			{
				_log.LogDebug("Creating new template with name {Id}", id);
				await _templateRemoval.RemoveAsync(id, workspace);
			}
		}
		
		[SubCommand]
		public class Workspace
		{
			private readonly ILogger<Workspace> _log;
			private readonly IWorkspaceCreation _workspaceCreation;

			public Workspace(ILogger<Workspace> log, IWorkspaceCreation workspaceCreation)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_workspaceCreation = workspaceCreation ?? throw new ArgumentNullException(nameof(workspaceCreation)) ;
			}


			[Command(Name = "create")]
			public async Task Create(string id)
			{
				_log.LogDebug("Creating new workspace with name {Id}", id);
				await _workspaceCreation.CreateAsync(id);
			}
		}
	}
}