using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QuestionViewModel
	{
		[Required]
		[DisplayName("Question title")]
		public string Title { get; set; }

		[Required]
		[DisplayName("Question content")]
		public string Content { get; set; }

		public QuestionViewModel() { }

		public QuestionViewModel(Shared.Entities.Question question)
		{
			Title = question.Title;
			Content = question.Content;
		}

		public Shared.Entities.Question ToQuestion()
		{
			Shared.Entities.Question question = new Shared.Entities.Question()
			{
				Title = Title,
				Content = Content
			};

			return question;
		}

		public Shared.Entities.Question UpdateQuestion(Shared.Entities.Question question)
		{
			question.Title = Title;
			question.Content = Content;

			return question;
		}
	}
}