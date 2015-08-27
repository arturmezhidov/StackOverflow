using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class ValidationException : Exception
	{
		public string Property { get; protected set; }

		public ValidationException(string message, string prop)
			: base(message)
		{
			Property = prop;
		}

		public override string ToString()
		{
			return String.Format("Message: {0}, Property: {1}.", Message, Property);
		}
	}
}
