using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Presentation.WebApp.Models.Answer
{
	public class LikeViewModel
	{
		public int AnswerId { get; set; }
		public int LikesCount { get; set; }
		public bool Liked { get; set; }
		public bool Success { get; set; }
	}
}