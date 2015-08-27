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
	}
}
