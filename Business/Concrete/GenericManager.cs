using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T>
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Add(T t)
        {
            _genericDal.Add(t);
        }

        public void Delete(T t)
        {
            _genericDal.Delete(t);
        }

        public T Get(int id)
        {
            return _genericDal.GetId(id);
        }

        public List<T> List()
        {
            return _genericDal.List();
        }

        public void Update(T t)
        {
            _genericDal.Update(t);
        }
    }
}
