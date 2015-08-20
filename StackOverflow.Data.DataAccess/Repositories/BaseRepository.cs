using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StackOverflow.Data.Contracts;

namespace StackOverflow.Data.DataAccess.Repositories
{
	public abstract class BaseRepository<T> : IRepository<T> where T : class
	{
		protected readonly DbContext context;
		protected readonly IDbSet<T> items;

		protected BaseRepository(DbContext context, IDbSet<T> items)
		{
			this.context = context;
			this.items = items;
		}

		public virtual T Get(int id)
		{
			T result = items.Find(id);
			return result;
		}

		public IEnumerable<T> GetAll()
		{
			return items;
		}

		public IEnumerable<T> Find(Func<T, bool> predicate)
		{
			IEnumerable<T> result = items.Where(predicate).ToList();
			return result;
		}

		public T Create(T item)
		{
			items.Add(item);
			return item;
		}

		public T Update(T item)
		{
			context.Entry(item).State = EntityState.Modified;
			return item;
		}

		public T Delete(int id)
		{
			T item = items.Find(id);
			if (item != null)
				items.Remove(item);
			return item;
		}
	}
}
