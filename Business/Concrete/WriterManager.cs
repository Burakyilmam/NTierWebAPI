using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : GenericManager<Writer>
    {
        public WriterManager(IGenericDal<Writer> genericDal) : base(genericDal)
        {
        }
    }
}
