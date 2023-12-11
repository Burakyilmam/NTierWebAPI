using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetId(int id);
        List<T> List();
    }
}
