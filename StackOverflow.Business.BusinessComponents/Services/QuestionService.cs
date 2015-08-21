using System;
using System.Collections.Generic;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
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

		public void Add(Question question)
		{
			question.Date = DateTime.Now;
			uow.Questions.Create(question);

			uow.Save();
		}

		public IEnumerable<Question> GetUserQuestions(object userId)
		{
			User user = uow.Users.Get(userId);
			IEnumerable<Question> result = user.Questions;
			return result;
		}

		public Question GetQuestionById(int id)
		{
			Question result = uow.Questions.Get(id);
			return result;
		}
	}
}
