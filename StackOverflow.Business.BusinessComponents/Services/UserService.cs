using System;
using System.ComponentModel;
using System.Linq;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessComponents.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork uow;

		public UserService(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public User GetById(object id)
		{
			User user = uow.Users.Get(id);
			return user;
		}

		public UserRating GetRating(object id)
		{
			User user = uow.Users.Get(id);

			int questions = user.Questions.Count;

			int answers = user.Answers.Count;

			int likeAnswers = (
				from answer
				in user.Answers
				where answer.Likes != null && answer.Likes.Count > 0
				select answer)
				.Count();

			int acceptedAnswers = (
				from answer
				in user.Answers
				where answer.IsAccepted
				select answer)
				.Count();

			UserRating rating = new UserRating
			{
				Questions = questions,
				Answers = answers,
				AcceptedAnswers = acceptedAnswers,
				LikeAnswers = likeAnswers
			};

			return rating;
		}
	}
}
