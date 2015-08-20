using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Business.BusinessModels;

namespace StackOverflow.Business.Contracts
{
	public interface IIdentityUserService
	{
		UserManager<IdentityUser> GetManager();
		IdentityUser Create(ApplicationUser appUser);
	}
}
