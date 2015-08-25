using System.Collections.Generic;

using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IQuestionService
	{
		Question Add(Question question);
		Question GetQuestionById(int id);
		IEnumerable<Question> GetAll();
		IEnumerable<Question> GetUserQuestions(object userId);
		IEnumerable<Question> GetActiveQuestions();
		void Update(Question question);
		
	}
}
