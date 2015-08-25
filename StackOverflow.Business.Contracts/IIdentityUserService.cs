using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StackOverflow.Business.Contracts
{
	public interface IIdentityUserService
	{
		UserManager<IdentityUser> GetManager();
	}
}
