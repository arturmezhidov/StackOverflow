using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.Shared.Entities;


namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class UserQuestionsViewModel : IEnumerable<Shared.Entities.Question>
	{
		private IEnumerable<Shared.Entities.Question> enumerable;

		public UserQuestionsViewModel(IEnumerable<Shared.Entities.Question> enumerable)
		{
			this.enumerable = enumerable;
		}

		public IEnumerator<Shared.Entities.Question> GetEnumerator()
		{
			return enumerable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}