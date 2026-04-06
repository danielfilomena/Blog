using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class User : BaseEntity
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }


        public virtual ICollection<Post>? Posts { get; set; }

    }
}
