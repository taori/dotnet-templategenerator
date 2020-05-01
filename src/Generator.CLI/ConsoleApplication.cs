using System.Threading.Tasks;
using CommandDotNet;
using Microsoft.Extensions.Logging;

namespace Generator.CLI
{
	[Command]
	public class ConsoleApplication
	{
		[SubCommand]
		public class New
		{
			private readonly ILogger<New> _logger;
			
			public New(ILogger<New> logger)
			{
				_logger = logger;
			}

			[Command(Name = "template")]
			public int Template(string name)
			{
				_logger.LogDebug("Creating new template with name {name}", name);
				return 0;
			}
		}
	}
}