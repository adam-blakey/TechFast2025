using MudBlazor;

namespace RealtimeChat.Models;

public class User(string name, Color color)
{
    private readonly string _id = Guid.NewGuid().ToString();
    private readonly string _name = name;
    private readonly Color _color = color;

    public string Id => _id;
    public string Name => _name;
    public Color Color => _color;
    public string Initials => _name.Contains(' ')
        ? string.Concat(_name.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Take(2)
                             .Select(word => char.ToUpper(word[0])))
        : _name.Length >= 2
            ? _name[..2].ToUpper()
            : _name.ToUpper();
}
