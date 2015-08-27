using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IUserService
	{
		User GetById(string id);
		Rating GetRating(string id);
	}
}
