using System.Collections.Generic;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IQuestionService
	{
		void Add(Question question);
		IEnumerable<Question> GetUserQuestions(object userId);
		Question GetQuestionById(int id);
	}
}
