namespace ExcelAI.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAllAsQueryable();

        public IEnumerable<TEntity> GetAll();
        public TEntity Get(int id);
        public void Add(TEntity target);
        public void Update(TEntity target);
        public void Delete(int id);

        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetAsync(int id);
        public Task AddAsync(TEntity target);
        public Task UpdateAsync(TEntity target);
        public Task DeleteAsync(int id);
    }
}
