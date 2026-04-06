using Blog.Data.Context;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories
{
    public class PostRepository : IPostRepository
    {


        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }


        public async Task<Post?> GetPost(Guid id)
        {
            return await _context.Post.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _context.Post.ToListAsync();
        }
       
        public async Task<bool> SavePost(Post post)
        {
            
            var success = false;

            try
            {

                if (post.Id == Guid.Empty)
                {

                    post.Id = Guid.NewGuid();
                    post.DateCreate = DateTime.Now;

                    _context.Post.Add(post);

                }
                else
                {
                    post.DateCreate = DateTime.Now;
                    _context.Update(post);

                }

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    success = true;

            }
            catch (Exception ex)
            {

                throw new Exception($"Ocorreu o erro: { ex.Message } ao tentar salvar o Post");
            }
            
            return success;

        }

        public async Task<bool> DetelePost(Guid id)
        {

            var post = await GetPost(id);

            if (post == null)
                throw new Exception("Registro não encontrado!");

            _context.Post.Remove(post);
            var result = await _context.SaveChangesAsync();

            if(result > 0)
                return true;


            return false;
        }
    }
}
