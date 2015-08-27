using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IAnswerService
	{
		IEnumerable<Answer> GetAll();
		IEnumerable<Answer> GetOfQuestion(int id);
		Answer Create(string userId, int questionId, string answer);
		bool IsLike(string userId, int answerId);
		UserLike Liking(string userId, int answerId);
		bool Accept(string userId, int answerId);
	}
}
