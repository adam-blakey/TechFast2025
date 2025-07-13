using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;

public class CharacterHub : Hub
{
    public async Task UpdatePosition(string userId, Game.Models.CharacterState state, [FromServices] Game.Data.CharacterService characterService)
    {
        await Clients.All.SendAsync("ReceivePosition", userId, state);
        characterService.UpdateCharacterState(userId, state);
    }

    public async Task RemoveCharacter(string userId, [FromServices] Game.Data.CharacterService characterService)
    {
        await Clients.All.SendAsync("ReceiveCharacterRemoval", userId);
        characterService.RemoveCharacter(userId);
    }
}
