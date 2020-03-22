using System;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Generator.CLI.Component.Parser;
using Microsoft.Extensions.Logging;

namespace Generator.CLI.Dependencies
{
	public class ServiceInjectorMiddleware : MiddlewareExtension
	{
		/// <inheritdoc />
		public override MiddlewareOrder Order => MiddlewareOrder.Configuration;

		/// <inheritdoc />
		protected override async Task OnExecute(InvocationContext context, Func<InvocationContext, Task> next)
		{
			context.BindingContext.AddService(typeof(ILoggerFactory), provider => new LoggerFactory());
			// context.BindingContext.AddService(typeof(ILogger<>), );
			await next.Invoke(context);
		}
	}
}