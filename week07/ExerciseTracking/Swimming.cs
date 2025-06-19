using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersPerKm = 1000;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / MetersPerKm;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetDurationMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }
}