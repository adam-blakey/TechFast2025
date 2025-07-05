using Microsoft.AspNetCore.Components;
using MoreLinq;
using RealtimeChat.Models;

namespace RealtimeChat.Services;

public class ChatService {
    private readonly List<Chat> _chats = [];
    private readonly ProfanityFilter.ProfanityFilter _profanityFilter = new();
    public event Action? UpdateHandler;

    public void Add(User user, string message)
    {
        _chats.Add(new Chat(user, message));
        UpdateHandler?.Invoke();
    }

    public IEnumerable<IGrouping<string, Chat>> GroupedChats => _chats.GroupAdjacent(c => c.UserId);

    public bool ContainsProfanity(string message) => _profanityFilter.DetectAllProfanities(message).Any();

    public void Clear()
    {
        _chats.Clear();
        UpdateHandler?.Invoke();
    }
}
