using MoreLinq;
using RealtimeChat.Models;

namespace RealtimeChat.Services;

public class ChatService {
    private readonly List<Chat> _chats = [];

    public void Add(User user, string message) => _chats.Add(new Chat(user, message));

    public IEnumerable<IGrouping<string, Chat>> GroupedChats => _chats.GroupAdjacent(c => c.UserId);
}
