using System;
using System.Linq.Expressions;

namespace Backend.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> expression);
		T GetById(int id);
		void Add(T entity);
		void AddAll(IEnumerable<T> entities);
		void Update(T entity);
		void Delete(T entity);
	}
}

