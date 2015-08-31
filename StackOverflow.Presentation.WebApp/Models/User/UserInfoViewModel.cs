using StackOverflow.Presentation.WebApp.Models.Question;

namespace StackOverflow.Presentation.WebApp.Models.User
{
	public class UserInfoViewModel
	{
		public UserViewModel User { get; set; }
		public RatingViewModel Rating { get; set; }
		public QuestionInfoCollectionViewModel Questions { get; set; }
	}
}