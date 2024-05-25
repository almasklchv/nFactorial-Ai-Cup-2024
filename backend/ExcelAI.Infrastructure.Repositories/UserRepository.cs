using ExcelAI.Domain.Users;
using ExcelAI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace ExcelAI.Infrastructure.Repositories
{
    public sealed class UserRepository : IRepository<User> 
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext context)
            => this.context = context;

        public IQueryable<User> GetAllAsQueryable()
        {
            return this.context.Users.AsQueryable();
        }

        #region SYNC_OPERATIONS
        public IEnumerable<User> GetAll()
        {
            return this.context.Users.ToArray();
        }
        public User Get(int id)
        {
            return this.context.Users.FirstOrDefault(user => user.Id == id) 
                ?? throw new IndexOutOfRangeException($"There is no User with Id={id}");
        }
        public void Add(User target)
        {
            this.context.Users.Add(target);
            this.context.SaveChanges();
        }
        public void Update(User target)
        {
            this.context.Attach(target);
            this.context.Entry(target).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void Delete(int id)
        {
            var target = this.Get(id);
            if (target != null)
            {
                this.context.Remove(target);
                this.context.SaveChanges();
                return;
            }
            throw new IndexOutOfRangeException($"There is no User with Id={id}");
        }
        #endregion

        #region ASYNC_OPERATIONS
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.context.Users.ToArrayAsync();
        }
        public async Task<User> GetAsync(int id)
        {
            return await this.context.Users.FirstOrDefaultAsync(user => user.Id == id)
                ?? throw new IndexOutOfRangeException($"There is no User with Id={id}");
        }
        public async Task AddAsync(User target)
        {
            await this.context.AddAsync(target);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User target)
        {
            this.context.Attach(target);
            this.context.Entry(target).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var target = await this.GetAsync(id);
            if (target != null)
            {
                this.context.Remove(target);
                await this.context.SaveChangesAsync();
                return;
            }
            throw new IndexOutOfRangeException($"There is no User with Id={id}");
        }
        #endregion
    }
}
