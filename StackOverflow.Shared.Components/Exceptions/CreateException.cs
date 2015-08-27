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
		public CreateException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}, Owner: {1}, Target: {2}.", Message, Owner, Target);
		}
	}
}
