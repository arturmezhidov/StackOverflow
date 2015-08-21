using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QestionViewModel
	{
		[Required]
		[DisplayName("Question title")]
		
		public string Title { get; set; }
		[Required]
		[DisplayName("Question content")]
		public string Content { get; set; }
	}
}