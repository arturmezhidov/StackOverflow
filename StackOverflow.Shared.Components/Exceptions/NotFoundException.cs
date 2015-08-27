using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class NotFoundException : Exception
	{
		public object TargetObject { get; set; }

		public NotFoundException()
		{
		}

		public NotFoundException(string message)
			: base(message)
		{
		}

		public NotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
