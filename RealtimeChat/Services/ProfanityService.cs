namespace RealtimeChat.Services
{
    public class ProfanityService
    {
        private readonly ProfanityFilter.ProfanityFilter _profanityFilter = new();
        public bool ContainsProfanity(string message) => _profanityFilter.DetectAllProfanities(message).Any();
    }
}
