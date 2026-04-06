using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces
{
    public interface IPostRepository
    {

        Task<Post?> GetPost(Guid id);
        Task<IEnumerable<Post>> GetAllPost();
        Task<bool> SavePost(Post post);               
        Task<bool> DetelePost(Guid id);

    }
}
