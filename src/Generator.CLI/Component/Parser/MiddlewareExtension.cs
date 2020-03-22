using System;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace Generator.CLI.Component.Parser
{
	public abstract class MiddlewareExtension
	{
		public readonly InvocationMiddleware Invoker;

		protected MiddlewareExtension()
		{
			Invoker = Execute;
		}

		public abstract MiddlewareOrder Order { get; }

		private async Task Execute(InvocationContext context, Func<InvocationContext, Task> next)
		{
			await OnExecute(context, next);
		}

		protected abstract Task OnExecute(InvocationContext context, Func<InvocationContext, Task> next);
	}
}