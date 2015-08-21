using System.ComponentModel;

namespace StackOverflow.Presentation.WebApp.Models.User
{
	public class UserInfoViewModel
	{
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[DisplayName("Last name")]
		public string LastName { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Nickname")]
		public string Nickname { get; set; }

		[DisplayName("Post")]
		public string Post { get; set; }

		[DisplayName("Experience")]
		public byte Experience { get; set; }

		[DisplayName("Technologies")]
		public string Technologies { get; set; }

		[DisplayName("All my questions")]
		public int Questions { get; set; }

		[DisplayName("All my answers")]
		public int Answers { get; set; }

		[DisplayName("Liked my answers")]
		public int LikeAnswers { get; set; }

		[DisplayName("Accepted my answers")]
		public int AcceptedAnswers { get; set; }
	}
}