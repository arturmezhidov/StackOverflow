using System;
using System.Collections.Generic;

namespace StackOverflow.Shared.Entities
{
	public class Question
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public bool IsClosed { get; set; }
		public DateTime Date { get; set; }

		public string UserId { get; set; }
		public virtual User User { get; set; }

		public virtual ICollection<Answer> Answers { get; set; }
	}
}
