using System;
using System.Collections;
using System.Collections.Generic;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QuestionInfoCollectionViewModel : IEnumerable<QuestionInfoViewModel>
	{
		private IList<QuestionInfoViewModel> list;

		public QuestionInfoCollectionViewModel(IEnumerable<Shared.Entities.Question> questions)
		{
			list = new List<QuestionInfoViewModel>();

			foreach (Shared.Entities.Question question in questions)
			{
				list.Add(new QuestionWithAnswersViewModel(question));
			}
		}

		public IEnumerator<QuestionInfoViewModel> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}