using System.Collections.Generic;
using StackOverflow.Presentation.WebApp.Models.Question;

namespace StackOverflow.Presentation.WebApp.Models.User
{
	public class UserInfoViewModel
	{
		public UserViewModel User { get; set; }
		public RatingViewModel Rating { get; set; }
		public IEnumerable<QuestionViewModel> Questions { get; set; }
	}
}