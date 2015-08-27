using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class QuestionClosedException : Exception
	{		
		public object QuestionId { get; set; }

		public QuestionClosedException(string message)
			: base(message)
		{
		}
		public QuestionClosedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}, QuestionId: {1}.", Message, QuestionId);
		}
	}
}
