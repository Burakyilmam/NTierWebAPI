using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookDal
    {
        public BookRepository(DataContext context) : base(context)
        {
        }
    }
}
