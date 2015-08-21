using System;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Shared.Entities;

namespace StackOverflow.Data.Contracts
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<User> Users { get; }
		IRepository<Question> Questions { get; }
		IRepository<Answer> Answers { get; }
		IRepository<Like> Likes { get; }
		IdentityDbContext<User> IdentityUsers { get; }
		void Save();
	}
}
