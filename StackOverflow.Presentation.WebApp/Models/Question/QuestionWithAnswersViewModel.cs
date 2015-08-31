using System;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QuestionWithAnswersViewModel : QuestionInfoViewModel
	{
		public bool IsOwner { get; set; }

		public QuestionWithAnswersViewModel() { }

		public QuestionWithAnswersViewModel(Shared.Entities.Question question) : base(question) { }
	}
}