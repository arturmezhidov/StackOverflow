using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Presentation.WebApp.Models.Account
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Nickname")]
		public string Nickname { get; set; }

		[Display(Name = "Post")]
		public string Post { get; set; }

		[Display(Name = "Experience")]
		public byte? Experience { get; set; }

		[Display(Name = "Technologies")]
		public string Technologies { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}