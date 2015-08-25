using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Presentation.WebApp.Models.Answer
{
	public class AnswerPostModel
	{
		public string Description { get; set; }
		public int QuestionId { get; set; }
	}
}