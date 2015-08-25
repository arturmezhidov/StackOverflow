using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessComponents.Services
{
	public class AnswerService : IAnswerService
	{
		private readonly IUnitOfWork uow;

		public AnswerService(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public IEnumerable<Answer> GetAll()
		{
			return uow.Answers.GetAll();
		}

		public IEnumerable<Answer> GetOfQuestion(int id)
		{
			Question question = uow.Questions.Get(id);
			return question.Answers;
		}

		public Answer Create(string userId, int questionId, string description)
		{
			Answer answer = new Answer()
			{
				Description = description,
				Date = DateTime.Now,
				IsAccepted = false,
				UserId = userId,
				QuestionId = questionId
			};

			answer = uow.Answers.Create(answer);
			answer.User = uow.Users.Get(userId);
			uow.Save();
	
			return answer;
		}

		public bool IsLike(string userId, int answerId)
		{
			Answer answer = uow.Answers.Get(answerId);
			Like like = answer.Likes.FirstOrDefault(item => item.UserId == userId);
			return like != null;
		}

		public UserLike Liking(string userId, int answerId)
		{
			Answer answer = uow.Answers.Get(answerId);
			Like like = answer.Likes.FirstOrDefault(item => item.UserId == userId);

			if (like == null)
			{
				uow.Likes.Create(new Like
				{
					AnswerId = answerId,
					UserId = userId
				});
			}
			else
			{
				uow.Likes.Delete(like.Id);
			}

			uow.Save();

			return new UserLike()
			{
				LikesCount = answer.Likes.Count,
				Liked = (like == null)
			};
		}
	}
}
