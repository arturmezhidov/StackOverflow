﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Business.Contracts
{
	public interface IIdentityUserService
	{
		UserManager<IdentityUser> GetManager();
	}
}
