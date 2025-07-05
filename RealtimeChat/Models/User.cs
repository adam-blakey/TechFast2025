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
        ? string.Concat(_name.Split(' ').Select(word => word[0].ToString().ToUpper())) 
        : _name[..2].ToUpper();
}
