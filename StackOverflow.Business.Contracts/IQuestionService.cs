using System.Collections.Generic;

using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IQuestionService
	{
		Question Add(Question question);
		IEnumerable<Question> GetAll();
		Question GetById(int id);
		IEnumerable<Question> GetUserQuestions(object userId);
		IEnumerable<Question> GetActiveQuestions();
		void Update(Question question);
		bool IsOwner(string userId, int questionId);
		
	}
}
