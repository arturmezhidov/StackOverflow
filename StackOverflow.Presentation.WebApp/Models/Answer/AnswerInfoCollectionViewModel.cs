using System.Collections;
using System.Collections.Generic;

namespace StackOverflow.Presentation.WebApp.Models.Answer
{
	public class AnswerInfoCollectionViewModel : IEnumerable<AnswerInfoViewModel>
	{
		private IList<AnswerInfoViewModel> list;

		public AnswerInfoCollectionViewModel(IEnumerable<Shared.Entities.Answer> answers)
		{
			list = new List<AnswerInfoViewModel>();

			foreach (Shared.Entities.Answer answer in answers)
			{
				list.Add(new AnswerInfoViewModel(answer));
			}
		}

		public IEnumerator<AnswerInfoViewModel> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}