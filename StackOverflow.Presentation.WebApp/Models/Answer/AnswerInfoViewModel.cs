namespace StackOverflow.Presentation.WebApp.Models.Answer
{
	public class AnswerInfoViewModel
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string Date { get; set; }

		public string Time { get; set; }

		public bool IsAccepted { get; set; }

		public int LikesCount { get; set; }

		public bool Liked { get; set; }

		public string UserFirstName { get; set; }
		public string UserLastName { get; set; }

		public string UserId { get; set; }

		public AnswerInfoViewModel() { }

		public AnswerInfoViewModel(Shared.Entities.Answer answer)
		{
			Id = answer.Id;
			Description = answer.Description;
			IsAccepted = answer.IsAccepted;
			Date = answer.Date.ToShortDateString();
			Time = answer.Date.ToLongTimeString();
			LikesCount = answer.Likes == null ? 0 : answer.Likes.Count;
			UserId = answer.UserId;
			//UserFirstName = answer.User.FirstName;
			//UserLastName = answer.User.LastName;
		}
	}
}