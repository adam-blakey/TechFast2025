namespace Game.Data
{
    public class CharacterService
    {
        private readonly Dictionary<string, Models.CharacterState> _characters = new();
        public Dictionary<string, Game.Models.CharacterState> Characters => _characters;
        public void UpdateCharacterState(string userId, Models.CharacterState state)
        {
            _characters[userId] = state;
        }
        public void RemoveCharacter(string userId)
        {
            _characters.Remove(userId);
        }
    }
}
