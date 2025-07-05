using MoreLinq;
using RealtimeChat.Models;

namespace RealtimeChat.Services;

public class ChatService {
    private readonly List<Chat> _chats = [];
    private int MAX_CHAT_COUNT = 1000; 

    public event Action? UpdateHandler;

    public void Add(User user, string message)
    {
        if (_chats.Count >= MAX_CHAT_COUNT) _chats.RemoveAt(0); // Remove the oldest chat if the limit is reached
        _chats.Add(new Chat(user, message));
        UpdateHandler?.Invoke();
    }

    public IEnumerable<IGrouping<string, Chat>> GroupedChats => _chats.GroupAdjacent(c => c.UserId);

    public void Clear()
    {
        _chats.Clear();
        UpdateHandler?.Invoke();
    }
}
