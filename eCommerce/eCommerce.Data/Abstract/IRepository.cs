
using System.Linq.Expressions;


namespace eCommerce.Data.Abstract
{
    //tüm classlarda calısabilmesi için<T>
    public interface IRepository<T> where T : class
    {
        //CRUD DB Silme güncelleme ekleme işlemlerini yapacak repomuz

        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);  
        void Delete(T entity);
        int Save();

        //Asenkron metodlar
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveAsync();
    }
}
