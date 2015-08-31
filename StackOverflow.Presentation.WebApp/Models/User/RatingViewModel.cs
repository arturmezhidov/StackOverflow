using System.ComponentModel;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Presentation.WebApp.Models.User 
{
	public class RatingViewModel 
	{
		[DisplayName("All questions")]
		public int Questions { get; set; }

		[DisplayName("All answers")]
		public int Answers { get; set; }

		[DisplayName("Liked my answers")]
		public int LikeAnswers { get; set; }

		[DisplayName("Accepted my answers")]
		public int AcceptedAnswers { get; set; }

		public RatingViewModel(Rating rating)
		{
			Questions		= rating.Questions;
			Answers			= rating.Answers;
			LikeAnswers		= rating.LikeAnswers;
			AcceptedAnswers = rating.AcceptedAnswers;
		}
	}
}