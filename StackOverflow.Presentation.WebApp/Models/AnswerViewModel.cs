using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Presentation.WebApp.Models
{
	public class AnswerViewModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public bool IsAccepted { get; set; }
		public string Date { get; set; }
		public int LikesCount { get; set; }
		public bool Liked { get; set; }

		public string UserName { get; set; }
		public string UserId { get; set; }
	}
}