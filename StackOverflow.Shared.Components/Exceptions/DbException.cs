﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Components.Exceptions
{
	public class DbException : Exception
	{
		public string AdditionalInformation { get; set; }

		public DbException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public override string ToString()
		{
			return String.Format("Message: {0}.", Message);
		}
	}
}
