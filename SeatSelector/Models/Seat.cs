namespace SeatSelector.Models
{
    public class Seat(int X, int Y)
    {
        private int _x = X;
        private int _y = Y;
        private string _earmarkedBy = "";
        
        public int X => _x;
        public int Y => _y;

        public string Name => $"{(char)(_x + 'A' - 1)}{_y}";
        public void DoEarmark(string userId) => _earmarkedBy = (_earmarkedBy == userId) ? "" : userId;
        public bool IsEarmarked() => _earmarkedBy != "";
        public bool IsEarmarked(string userId) => _earmarkedBy == userId;
        public bool IsEarmarkedByAnother(string userId) => IsEarmarked() && !IsEarmarked(userId);
        public bool IsInteractable(string userId) => !IsEarmarked() || IsEarmarked(userId);

    }
}
