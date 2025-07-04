namespace RealtimeChat.Models;

public class Chat(User user, string message)
{
    private readonly string _userId = user.Id;
    private DateTime _createdAt = DateTime.UtcNow;
    private string _message = message;

    public string UserId => _userId;
    public DateTime CreatedAt => _createdAt;
    public string Message => _message;
}
