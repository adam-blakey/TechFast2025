namespace SeatSelector.Data;

public class PerformanceService
{
    private List<Models.Performance> _performances = [];

    public event Action? OnEarmark;
    public PerformanceService()
    {
        // Start with this example data.
        var thisTalk = new Models.Performance(
            name: "This talk",
            date: new DateOnly(2025, 7, 16),
            startTime: new TimeOnly(7, 30, 0),
            endTime: new TimeOnly(8, 30, 0),
            numberOfRows: 3, 
            numberOfColumns: 8
        );

        var someLaterTalk = new Models.Performance(
            name: "Some later talk",
            date: new DateOnly(2025, 7, 18),
            startTime: new TimeOnly(9, 0, 0),
            endTime: new TimeOnly(10, 30, 0),
            numberOfRows: 10,
            numberOfColumns: 20
        );

        _performances.Add(thisTalk);
        _performances.Add(someLaterTalk);
    }

    public List<Models.Performance> Performances => _performances;

    public Models.Performance? GetPerformance(string id) => _performances.FirstOrDefault(p => p.Id == id);

    public int GetSeatAvailability(string performanceId)
    {
        var performance = GetPerformance(performanceId);
        if (performance == null) return 0;

        return performance.Seats.Count() - performance.Seats.Count(s => s.IsEarmarked());
    }

    public void Earmark(string userId, Models.Performance performance, Models.Seat seat)
    {
        if (seat.IsEarmarkedByAnother(userId)) return;

        seat.DoEarmark(userId);
        OnEarmark?.Invoke();
    }
}
