using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class WriterRepository : GenericRepository<Writer>, IWriterDal
    {
        public WriterRepository(DataContext context) : base(context)
        {
        }
    }
}
