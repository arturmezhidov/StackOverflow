using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Components.Exceptions;
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
			IEnumerable<Answer> answers = null;

			try
			{
				answers = uow.Answers.GetAll();
			}
			catch (Exception e)
			{
				throw new DbException("Get all answers error.", e);
			}

			if (null == answers)
			{
				throw new NotFoundException("The result of all of the answers is null.");
			}

			return answers;
		}

		public IEnumerable<Answer> GetOfQuestion(int id)
		{
			Question question = null;

			try
			{
				question = uow.Questions.Get(id);

				if (null == question)
				{
					throw new Exception("The result of receiving the answer is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Get question by id error.", e)
				{
					TargetObject = id
				};
			}

			return question.Answers;
		}

		public Answer Create(string userId, int questionId, string description)
		{
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

			if (question.IsClosed)
			{
				throw new QuestionClosedException("Answer created error. This question is closed.")
				{
					QuestionId = questionId
				};
			}

			Answer answer = new Answer()
			{
				Description = description,
				Date = DateTime.Now,
				IsAccepted = false,
				UserId = userId,
				QuestionId = questionId
			};

			try
			{
				answer = uow.Answers.Create(answer);

				if (null == answer)
				{
					throw new Exception("The result of create the answer is null.");
				}
			}
			catch (Exception e)
			{
				throw new CreateException("Answer creating error.", e)
				{
					Owner = userId,
					Target = questionId
				};
			}

			try
			{
				uow.Save();
			}
			catch (Exception e)
			{
				throw new SaveException("Answers saving error.", e);
			}

			return answer;
		}

		public bool IsLike(string userId, int answerId)
		{
			Answer answer = null;

			try
			{
				answer = uow.Answers.Get(answerId);

				if (null == answer)
				{
					throw new Exception("The result of the answer is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving answer by id.", e)
				{
					TargetObject = answerId
				};
			}

			Like like = null;

			try
			{
				like = answer.Likes.FirstOrDefault(item => item.UserId == userId);
			}
			catch (Exception e)
			{
				throw new DbException("Get likes of answers error.", e)
				{
					AdditionalInformation = String.Format("Answer id: {0}", answer.Id)
				};
			}

			return like != null;
		}

		public UserLike Liking(string userId, int answerId)
		{
			Answer answer = null;

			try
			{
				answer = uow.Answers.Get(answerId);

				if (null == answer)
				{
					throw new Exception("The result of the answer is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving answer by id.", e)
				{
					TargetObject = answerId
				};
			}

			Like like = null;

			try
			{
				like = answer.Likes.FirstOrDefault(item => item.UserId == userId);
			}
			catch (Exception e)
			{
				throw new DbException("Get likes of answers error.", e)
				{
					AdditionalInformation = String.Format("Answer id: {0}", answer.Id)
				};
			}

			if (null == like)
			{
				try
				{
					uow.Likes.Create(new Like
					{
						AnswerId = answerId,
						UserId = userId
					});
				}
				catch (Exception e)
				{
					throw new CreateException("Like creating error.", e)
					{
						Owner = userId,
						Target = answerId
					};
				}
			}
			else
			{
				try
				{
					uow.Likes.Delete(like.Id);
				}
				catch (Exception e)
				{
					throw new DeleteException("Like deleting error.", e)
					{
						Deletor = String.Format("User id: {0}", userId),
						DeletingObject = like.Id
					};
				}

			}

			try
			{
				uow.Save();
			}
			catch (Exception e)
			{
				throw new SaveException("Likes saving error.", e);
			}

			return new UserLike()
			{
				LikesCount = answer.Likes.Count,
				Liked = (like == null)
			};
		}

		public bool Accept(string userId, int answerId)
		{
			Answer answer = null;

			try
			{
				answer = uow.Answers.Get(answerId);

				if (null == answer)
				{
					throw new Exception("The result of the answer is null.");
				}
			}
			catch (Exception e)
			{
				throw new NotFoundException("Error retrieving answer by id.", e)
				{
					TargetObject = answerId
				};
			}

			if (answer.Question.UserId != userId)
			{
				return false;
			}

			IEnumerable<Answer> answers = null;

			try
			{
				answers = answer.Question.Answers;
			}
			catch (Exception e)
			{
				throw new DbException("Get answers of question error.", e)
				{
					AdditionalInformation = String.Format("Answer id: {0}", answer.Id)
				};
			}

			foreach (Answer item in answers)
			{
				item.IsAccepted = false;
			}

			answer.IsAccepted = true;
			answer.Question.IsClosed = true;

			try
			{
				uow.Save();
			}
			catch (Exception e)
			{
				throw new SaveException("Accepted saving error.", e);
			}

			return true;
		}
	}
}
