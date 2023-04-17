
namespace CoursesTikects.DAL.Repos.Inertfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public void Update(T entity);
        public void Delete(T entity);
        public Task Add(T entity);
        public Task SaveCahnges();
    }
}
