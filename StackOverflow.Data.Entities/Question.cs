using System;
using System.Collections.Generic;

namespace StackOverflow.Data.Entities
{
	public class Question
	{
		public int Id { get; set; }
		public string Header { get; set; }
		public string Content { get; set; }
		public bool IsClosed { get; set; }
		public DateTime CraeteDate { get; set; }


		public string UserId { get; set; }
		public virtual User User { get; set; }

		public virtual ICollection<Question> Answers { get; set; }
	}
}
