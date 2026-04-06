using AutoMapper;
using Blog.Application.Dtos;
using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;

namespace Blog.Application.Service
{
    public class PostService : IPostService
    {


        private readonly IPostRepository _postRepository;
        private readonly INotificationService _notification;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, INotificationService notification, IMapper mapper)
        {
            _postRepository = postRepository;
            _notification = notification;
            _mapper = mapper;
        }
        
        

        public async Task<IEnumerable<PostDto>> GetAllPost()
        {

            var posts = await _postRepository.GetAllPost();
            return _mapper.Map<IEnumerable<PostDto>>(posts);

        }

        public async Task<bool> SavePost(PostDto dto)
        {

            var post = _mapper.Map<Post>(dto);
            var result = await _postRepository.SavePost(post);
            await _notification.NotifyNewPost(post.Title);

            return result;

        }

        public async Task<bool> DeletePost(Guid postId)
        {

            var result = await _postRepository.DetelePost(postId);
            return result;

        }
             
    }
}
