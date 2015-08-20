using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Business.BusinessModels;
using StackOverflow.Business.Contracts;
using StackOverflow.Data.Contracts;
using StackOverflow.Data.Entities;

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

		public IdentityUser Create(ApplicationUser appUser)
		{
			User user = new User()
			{
				UserName = appUser.Email,
				FirstName = appUser.FirstName,
				LastName = appUser.LastName,
				Email = appUser.Email,
				//Nickname = appUser.Nickname,
				Post = appUser.Post,
				Experience = appUser.Experience,
				Technologies = appUser.Technologies
			};

			return user;
		}
	}
}
