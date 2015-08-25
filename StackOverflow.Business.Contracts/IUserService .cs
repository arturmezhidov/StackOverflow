using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IUserService
	{
		User GetById(object id);
		Rating GetRating(object id);
	}
}
