using Microsoft.AspNetCore.SignalR;

public class CharacterHub : Hub
{
    public async Task UpdatePosition(string userId, Game.Models.CharacterState state)
    {
        await Clients.All.SendAsync("ReceivePosition", userId, state);
    }
}
