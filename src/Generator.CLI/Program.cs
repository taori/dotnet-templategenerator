using System;
using System.CommandLine.Builder;

namespace Generator.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			CommandLineBuilder builder =new CommandLineBuilder();
			var parser = builder.Build();
			parser.Parse(args);
		}
	}
}
