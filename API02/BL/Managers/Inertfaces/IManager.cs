namespace CoursesTikects.BL.Managers.Inertfaces
{
    public interface IManager<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByID(int id);
        public Task Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task SaveChanges();
    }
}
