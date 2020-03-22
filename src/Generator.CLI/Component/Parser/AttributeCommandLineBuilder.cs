using System;
using System.Collections.Generic;
using System.CommandLine.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Generator.CLI.Component.Parser
{
	public class AttributeCommandLineBuilder
	{
		private List<Type> _types = new List<Type>();
		private List<MiddlewareExtension> _middlewareExtensions = new List<MiddlewareExtension>();
		
		public AttributeCommandLineBuilder WithTypes(IEnumerable<Type> types)
		{
			_types.AddRange(types);
			return this;
		}

		public AttributeCommandLineBuilder UseMiddleware(MiddlewareExtension middleware)
		{
			_middlewareExtensions.Add(middleware);
			return this;
		}

		public System.CommandLine.Parsing.Parser Build()
		{
			var builder = new CommandLineBuilder();
			foreach (var extension in _middlewareExtensions)
			{
				builder.UseMiddleware(extension.Invoker, extension.Order);
			}

			return builder.Build();
		}
	}
}