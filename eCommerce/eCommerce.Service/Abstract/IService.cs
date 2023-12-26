using eCommerce.Data.Abstract;
using eCommerce.Entities;


namespace eCommerce.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}
