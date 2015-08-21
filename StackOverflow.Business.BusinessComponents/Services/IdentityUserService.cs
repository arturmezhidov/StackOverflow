using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.BusinessComponents.Services
{
	public class IdentityUserService : IIdentityUserService
	{
		private readonly IUnitOfWork uow;

		public IdentityUserService(IUnitOfWork uow)
		{
			this.uow = uow;
		}

		public UserManager<IdentityUser> GetManager()
		{
			return new UserManager<IdentityUser>(new UserStore<IdentityUser>(uow.IdentityUsers));
		}
	}
}
