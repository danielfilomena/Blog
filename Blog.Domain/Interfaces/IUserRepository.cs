using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces
{
    public interface IUserRepository
    {

        Task<bool> SaveUser(User user);
        Task<User?> GetUser(string userName);

    }
}
