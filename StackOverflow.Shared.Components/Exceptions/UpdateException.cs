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
	}
}
