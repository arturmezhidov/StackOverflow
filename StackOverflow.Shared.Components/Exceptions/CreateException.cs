using System;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class CreateException : Exception
	{
		public object Owner { get; set; }
		public object Target { get; set; }

		public CreateException()
		{
		}
		public CreateException(string message)
			: base(message)
		{
		}
		public CreateException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
