using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class SaveException : Exception
	{
		public SaveException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}.", Message);
		}
	}
}
