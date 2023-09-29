using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<User> GetUser()
        {
            return dbContext.Users.OrderByDescending(x => x.Orders.Count).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return dbContext.Users.Where(x => x.Status == Enums.UserStatus.Inactive).ToListAsync();
        }
    }
}
