using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class DeleteException : Exception
	{
		public object Deletor { get; set; }
		public object DeletingObject { get; set; }

		public DeleteException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}, Deletor: {1}, DeletingObject: {2}.", Message, Deletor, DeletingObject);
		}
	}
}
