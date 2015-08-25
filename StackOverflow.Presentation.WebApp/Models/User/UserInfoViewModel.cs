using System.Collections.Generic;
using System.ComponentModel;

namespace StackOverflow.Presentation.WebApp.Models.User
{
	public class UserInfoViewModel
	{
		public UserViewModel User { get; set; }
		public RatingViewModel Rating { get; set; }
		public IEnumerable<StackOverflow.Shared.Entities.Question> Questions { get; set; }
	}
}