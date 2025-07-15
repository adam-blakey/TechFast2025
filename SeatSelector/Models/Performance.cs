namespace SeatSelector.Models
{
    public class Performance(string name, DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        private string _id = Guid.NewGuid().ToString();
        private string _name = name;
        private DateOnly _date = date;
        private TimeOnly _startTime = startTime;
        private TimeOnly _endTime = endTime;
        private List<Seat> _seats = [];

        public Performance(string name, DateOnly date, TimeOnly startTime, TimeOnly endTime, int numberOfRows, int numberOfColumns) : this(name, date, startTime, endTime)
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= numberOfColumns; j++)
                {
                    _seats.Add(new Seat(j, i));
                }
            }
        }

        public string Name => _name;
        public string Id => _id;
        public string DateFormatted => _date.ToString("dddd, dd MMMM yyyy");
        public string TimeRangeFormatted => $"{_startTime:HH:mm}–{_endTime:HH:mm}";

        public IEnumerable<Seat> Seats => _seats;
    }
}
