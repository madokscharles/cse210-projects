using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _activityDate;
    private int _durationMinutes;

    public Activity(DateTime activityDate, int durationMinutes)
    {
        _activityDate = activityDate;
        _durationMinutes = durationMinutes;
    }

    public DateTime GetActivityDate()
    {
        return _activityDate;
    }

    public int GetDurationMinutes()
    {
        return _durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual void GetSummary()
    {
        string activityType = GetType().Name;
        string formattedDate = _activityDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine($"{formattedDate} {activityType} ({_durationMinutes} min): " +
            $"Distance: {GetDistance():0.00} km, " +
            $"Speed: {GetSpeed():0.00} kph, " +
            $"Pace: {GetPace():0.00} min per km");
    }
}