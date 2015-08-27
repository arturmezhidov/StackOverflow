using System;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class UpdateException : Exception
	{
		public object ObjectId { get; set; }

		public UpdateException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}, ObjectId: {1}.", Message, ObjectId);
		}
	}
}
