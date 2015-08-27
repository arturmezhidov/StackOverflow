using System;
using System.Linq;

using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Components.Exceptions;
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

		public User GetById(string id)
		{
			User user = null;

			try
			{
				user = uow.Users.Get(id);

				if (null == user)
				{
					throw new Exception("The result of receiving the user is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving user by id.", e)
				{
					TargetObject = id
				};
			}

			return user;
		}

		public Rating GetRating(string id)
		{
			User user = GetById(id);
			Rating rating = new Rating();

			try
			{
				rating.Questions = user.Questions.Count;
			}
			catch (Exception e)
			{
				throw new DbException("Error get question count of user.", e);
			}

			try
			{
				rating.Answers = user.Answers.Count;
			}
			catch (Exception e)
			{
				throw new DbException("Error get answers count of user.", e);
			}

			try
			{
				rating.LikeAnswers = (
					from answer
					in user.Answers
					where answer.Likes != null && answer.Likes.Count > 0
					select answer)
					.Count();
			}
			catch (Exception e)
			{
				throw new DbException("An error in determining the amount mentioned answers.", e);
			}

			try
			{
				rating.AcceptedAnswers = (
					from answer
					in user.Answers
					where answer.IsAccepted
					select answer)
					.Count();
			}
			catch (Exception e)
			{
				throw new DbException("An error in determining the accepted answers.", e);
			}

			return rating;
		}
	}
}
