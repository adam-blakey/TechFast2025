using RealtimeChat.Models;

namespace RealtimeChat.Services;

public class UserService
{
    private List<User> _users = [];

    public event Action? UpdateHandler;

    public User? GetById(string id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User Add(string name)
    {
        User user = new(name, MudBlazor.Color.Primary);
        _users.Add(user);
        return user;
    }

    public bool NameExists(string name) => _users.Any(u => u.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));

    public void Clear()
    {
        _users.Clear();
        UpdateHandler?.Invoke();
    }
}
