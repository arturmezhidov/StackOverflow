using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IUserService
	{
		User GetById(object id);
		UserRating GetRating(object id);
	}
}
