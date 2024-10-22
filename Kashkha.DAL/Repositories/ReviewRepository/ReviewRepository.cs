using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class ReviewRepository:GenericRepository<Review>,IReviewRepository
	{
		private readonly KashkhaContext _context;

		public ReviewRepository(KashkhaContext context):base(context)
        {
            _context = context;
		}
    }
}
