using eCommerce.Data;
using eCommerce.Data.Concrete;
using eCommerce.Entities;
using eCommerce.Service.Abstract;

namespace eCommerce.Service.Concrete
{
    public class Service<T> : Repository<T> , IService<T> where T : class, IEntity, new()
    {
        //servis üzerinden veri tabanı işlemleri
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
