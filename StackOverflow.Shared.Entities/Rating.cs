using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Shared.Entities
{
	public class Rating
	{
		public int Questions { get; set; }
		public int Answers { get; set; }
		public int LikeAnswers { get; set; }
		public int AcceptedAnswers { get; set; }
	}
}
