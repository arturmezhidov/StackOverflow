using System;
using System.Collections.Generic;
using System.Collections;

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

		public Question Add(Question question)
		{
			question.Date = DateTime.Now;
			question = uow.Questions.Create(question);

			uow.Save();

			return question;
		}

		public IEnumerable<Question> GetAll() 
		{
			IEnumerable<Question> result = uow.Questions.GetAll();
			return result;
		}

		public IEnumerable<Question> GetUserQuestions(object userId) 
		{
			User user = uow.Users.Get(userId);
			IEnumerable<Question> result = user.Questions;
			return result;
		}

		public IEnumerable<Question> GetActiveQuestions() 
		{
			List<Question> list = new List<Question>(uow.Questions.GetAll());

			list.Sort(delegate(Question question1, Question question2) 
			{
				//DateTime date1 = (from answer 
				//				 in question1.Answers.
				//				 orderby answer.Date
				//				 select answer.Date).Select()

				return question2.Date.CompareTo(question1.Date);
			});

			return list;
		}

		public Question GetQuestionById(int id)
		{
			Question result = uow.Questions.Get(id);
			return result;
		}

		public void Update(Question question) 
		{
			uow.Questions.Update(question);
			uow.Save();
		}
	}
}
