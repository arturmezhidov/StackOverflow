using System.ComponentModel;

namespace StackOverflow.Presentation.WebApp.Models.User 
{
	public class UserViewModel 
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
		public byte? Experience { get; set; }

		[DisplayName("Technologies")]
		public string Technologies { get; set; }

		public UserViewModel() { }

		public UserViewModel(Shared.Entities.User user)
		{
			FirstName		= user.FirstName;
			LastName		= user.LastName;
			Email			= user.Email;
			Nickname		= user.Nickname;
			Post			= user.Post;
			Experience		= user.Experience;
			Technologies	= user.Technologies;
		}
	}
}