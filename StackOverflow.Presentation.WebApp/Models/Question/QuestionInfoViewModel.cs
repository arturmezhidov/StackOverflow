using System;

namespace StackOverflow.Presentation.WebApp.Models.Question
{
	public class QuestionInfoViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime Date { get; set; }

		public bool IsClosed { get; set; }

		public string UserId { get; set; }

		public string UserFirstName { get; set; }

		public string UserLastName { get; set; }

		public QuestionInfoViewModel() { }

		public QuestionInfoViewModel(Shared.Entities.Question question)
		{
			Id = question.Id;
			Title = question.Title;
			Content = question.Content;
			Date = question.Date;
			IsClosed = question.IsClosed;
			UserId = question.UserId;
			UserFirstName = question.User.FirstName;
			UserLastName = question.User.LastName;
		}
	}
}