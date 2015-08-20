using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Business.BusinessModels
{
	public class ApplicationUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Nickname { get; set; }
		public string Post { get; set; }
		public byte? Experience { get; set; }
		public string Technologies { get; set; }
	}
}
