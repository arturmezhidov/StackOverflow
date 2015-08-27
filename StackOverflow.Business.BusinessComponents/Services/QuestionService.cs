using System;
using System.Collections.Generic;
using System.Linq;

using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Components.Exceptions;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessComponents.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IUnitOfWork uow;

		public QuestionService(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public Question Add(Question question)
		{
			if (null == question)
			{
				throw new NullReferenceException("Question creating error. Parameter is null.");
			}

			string userId = question.UserId;
			question.Date = DateTime.Now;

			try
			{
				question = uow.Questions.Create(question);

				if (null == question)
				{
					throw new Exception("The result of create the question is null.");
				}
			}
			catch (Exception e)
			{
				throw new CreateException("Question creating error.", e)
				{
					Owner = userId
				};
			}

			try
			{
				uow.Save();
			}
			catch (Exception e)
			{
				throw new SaveException("Questions saving error.", e);
			}

			return question;
		}

		public IEnumerable<Question> GetAll()
		{
			IEnumerable<Question> result = null;

			try
			{
				result = uow.Questions.GetAll();
			}
			catch (Exception e)
			{
				throw new DbException("Get all questions error.", e);
			}

			if (null == result)
			{
				throw new NotFoundException("The result of all of the questions is null.");
			}

			return result;
		}

		public IEnumerable<Question> GetUserQuestions(object userId)
		{
			User user = null;

			try
			{
				user = uow.Users.Get(userId);

				if (null == user)
				{
					throw new Exception("The result of receiving the user is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving user by id.", e)
				{
					TargetObject = userId
				};
			}

			IEnumerable<Question> result = user.Questions;

			return result;
		}

		public IEnumerable<Question> GetActiveQuestions()
		{
			List<Question> list = new List<Question>(uow.Questions.GetAll());

			list.Sort(delegate(Question question1, Question question2)
			{
				DateTime date1 = question1.Date;
				DateTime date2 = question2.Date;

				if (question1.Answers.Any())
				{
					DateTime answerDate = (from answer
											in question1.Answers
											select answer.Date)
											.Max();

					if (answerDate > date1)
					{
						date1 = answerDate;
					}
				}

				if (question2.Answers.Any())
				{
					DateTime answerDate = (from answer
											in question2.Answers
											select answer.Date)
											.Max();

					if (answerDate > date2)
					{
						date2 = answerDate;
					}
				}

				return date2.CompareTo(date1);
			});

			return list;
		}

		public Question GetById(int id)
		{
			Question result = null;

			try
			{
				result = uow.Questions.Get(id);

				if (null == result)
				{
					throw new Exception("The result of receiving the question is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving question by id.", e)
				{
					TargetObject = id
				};
			}

			return result;
		}

		public void Update(Question question)
		{
			try
			{
				uow.Questions.Update(question);
			}
			catch (Exception e)
			{
				throw new UpdateException("Question updating error.", e)
				{
					ObjectId = question.Id
				};
			}

			try
			{
				uow.Save();
			}
			catch (Exception e)
			{
				throw new SaveException("Updates saving error.", e);
			}
		}

		public bool IsOwner(string userId, int questionId)
		{
			User user = null;

			try
			{
				user = uow.Users.Get(userId);

				if (null == user)
				{
					throw new Exception("The result of receiving the user is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving user by id.", e)
				{
					TargetObject = userId
				};
			}

			Question question = null;

			try
			{
				question = uow.Questions.Get(questionId);

				if (null == question)
				{
					throw new Exception("The result of receiving the question is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving question by id.", e)
				{
					TargetObject = questionId
				};
			}

			bool result = user.Id.Equals(question.UserId);

			return result;
		}
	}
}
