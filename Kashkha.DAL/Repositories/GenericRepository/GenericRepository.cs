


namespace Kashkha.DAL
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly KashkhaContext _context;

		public GenericRepository(KashkhaContext context) {
			_context = context;
		}

		

		public void Add(T item)
		{
			_context.Set<T>().Add(item);
		}

		public void Delete(T item)
		{
			_context.Set<T>().Remove(item);
		}

		public T GetFirstOrDefault(int id)
		{
			return _context.Set<T>().Find(id)!;
		}

		public List<T> GetAll()
		{ 
			return _context.Set<T>().ToList(); 
		   
		}
		public void Update(T item)
		{
			_context.Set<T>().Update(item);
		}

     



        //public IEnumerable<T> GetAll(Expression<Func<T, bool>> pridecate, string? IncludWord)
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetFirstOrDefault(Expression<Func<T, bool>> pridecate, string? IncludWord)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
