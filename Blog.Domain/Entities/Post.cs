using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class Post : BaseEntity
    {

        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreate { get; set; }


        public virtual User? User { get; set; }

    }
}
