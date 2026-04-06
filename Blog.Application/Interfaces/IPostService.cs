using Blog.Application.Dtos;

namespace Blog.Application.Interfaces
{
    public interface IPostService
    {

        Task<IEnumerable<PostDto>> GetAllPost();
        Task<bool> SavePost(PostDto dto);
        Task<bool> DeletePost(Guid postId);

    }
}
