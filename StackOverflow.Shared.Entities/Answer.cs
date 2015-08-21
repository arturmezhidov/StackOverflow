using System;
using System.Collections.Generic;

namespace StackOverflow.Shared.Entities
{
	public class Answer
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public bool IsAccepted { get; set; }
		public DateTime Date { get; set; }

		public string UserId { get; set; }
		public virtual User User { get; set; }

		public int QuestionId { get; set; }
		public virtual Question Question { get; set; }

		public virtual ICollection<Like> Likes { get; set; }
	}
}
