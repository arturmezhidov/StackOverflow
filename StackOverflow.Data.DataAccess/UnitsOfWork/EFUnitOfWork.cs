using System;
using Microsoft.AspNet.Identity.EntityFramework;
using StackOverflow.Data.Contracts;
using StackOverflow.Data.DataAccess.DataContexts;
using StackOverflow.Data.DataAccess.Repositories;
using StackOverflow.Data.Entities;

namespace StackOverflow.Data.DataAccess.UnitsOfWork
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private readonly DataContext context;
		private UserRepository users;
		private QuestionRepository questions;
		private AnswerRepository answers;
		private LikeRepository likes;
		private bool disposed;

		public EFUnitOfWork(string connectionString)
		{
			context = new DataContext(connectionString);
		}

		public IRepository<User> Users
		{
			get
			{
				users = users ?? new UserRepository(context);
				return users;
			}
		}
		public IRepository<Question> Questions
		{
			get
			{
				questions = questions ?? new QuestionRepository(context);
				return questions;
			}
		}
		public IRepository<Answer> Answers
		{
			get
			{
				answers = answers ?? new AnswerRepository(context);
				return answers;
			}
		}
		public IRepository<Like> Likes
		{
			get
			{
				likes = likes ?? new LikeRepository(context);
				return likes;
			}
		}
		public IdentityDbContext<User> IdentityUsers
		{
			get
			{
				return (IdentityDbContext<User>)context;
				
			}
		}
 
		public void Save()
		{
			context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
				disposed = true;
			}
		}
	}
}
