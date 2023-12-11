using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : GenericManager<Book>
    {
        public BookManager(IGenericDal<Book> genericDal) : base(genericDal)
        {
        }
    }
}
