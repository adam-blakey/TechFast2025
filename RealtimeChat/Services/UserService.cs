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
        var allColors = Enum.GetValues<MudBlazor.Color>().Where(c => c != MudBlazor.Color.Default).ToList();
        MudBlazor.Color userColor;

        if (_users.Count < allColors.Count)
        {
            userColor = allColors[_users.Count];
        }
        else
        {
            var random = new Random();
            userColor = allColors[random.Next(allColors.Count)];
        }

        User user = new(name, userColor);
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
