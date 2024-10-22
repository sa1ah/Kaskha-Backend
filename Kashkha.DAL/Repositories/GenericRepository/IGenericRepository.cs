using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public interface IGenericRepository<T> where T : class
	{

        //to use (Includ Keyword or where keyword)
        //Expression<Func<T, bool>> pridecate, string? IncludWord
        public List<T> GetAll();
		public T GetFirstOrDefault(int id);
		public void Add(T item);
		public void Update(T item);
		public void Delete(T item);

	}
}
