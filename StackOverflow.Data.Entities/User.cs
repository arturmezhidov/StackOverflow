using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StackOverflow.Data.Entities
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		//public string Nickname { get; set; }
		public string Post { get; set; }
		public byte? Experience { get; set; }
		public string Technologies { get; set; }

		public virtual ICollection<Question> Questions { get; set; }
		public virtual ICollection<Question> Answers { get; set; }
		public virtual ICollection<Question> Likes { get; set; }
	}
}
