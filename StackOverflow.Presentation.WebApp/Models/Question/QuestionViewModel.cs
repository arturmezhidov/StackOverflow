using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QuestionViewModel
	{
		public int Id { get; set; }

		[Required]
		[DisplayName("Question title")]
		public string Title { get; set; }

		[Required]
		[DisplayName("Question content")]
		public string Content { get; set; }

		[DisplayName("Date create")]
		public DateTime Date { get; set; }

		public string UserId { get; set; }
		public string UserName { get; set; }
		public bool IsClosed { get; set; }
		public bool IsOwner { get; set; }
	}
}