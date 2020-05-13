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
		public class New
		{
			private readonly ILogger<New> _log;
			private readonly ITemplateCreation _templateCreation;

			public New(ILogger<New> log, ITemplateCreation templateCreation)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_templateCreation = templateCreation ?? throw new ArgumentNullException(nameof(templateCreation));
			}

			[Command(Name = "template")]
			public async Task Template(string id)
			{
				_log.LogDebug("Creating new template with name {id}", id);
				await _templateCreation.CreateAsync(id);
			}
		}

		[SubCommand]
		public class Remove
		{
			private readonly ILogger<Remove> _log;
			private readonly ITemplateRemoval _templateRemoval;

			public Remove(ILogger<Remove> log, ITemplateRemoval templateRemoval)
			{
				_log = log ?? throw new ArgumentNullException(nameof(log));
				_templateRemoval = templateRemoval ?? throw new ArgumentNullException(nameof(templateRemoval));
			}
		}
	}
}