using System;
using System.Collections.Generic;

namespace StackOverflow.Data.Contracts
{
	public interface IRepository<T> where T : class
	{
		T Get(object id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Func<T, Boolean> predicate);
		T Create(T item);
		T Update(T item);
		T Delete(object id);
	}
}
