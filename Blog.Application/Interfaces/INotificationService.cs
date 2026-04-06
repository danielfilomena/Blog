namespace Blog.Application.Interfaces
{
    public interface INotificationService
    {

        Task NotifyNewPost(string title);

    }

}
