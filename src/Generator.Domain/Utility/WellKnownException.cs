using System;

namespace Generator.Domain.Utility
{
	public class WellKnownException : Exception
	{
		private int _exitCode = int.MinValue;

		public int ExitCode
		{
			get { return _exitCode; }
			set
			{
				if(value == 0)
					throw new ArgumentException("The value 0 is not a valid value for this exceptions exit code.");
				_exitCode = value;
			}
		}

		public WellKnownException(int exitCode, string message) : base(message)
		{
			ExitCode = exitCode;
		}

		public WellKnownException(int exitCode, string message, Exception innerException) : base(message, innerException)
		{
			ExitCode = exitCode;
		}
	}
}