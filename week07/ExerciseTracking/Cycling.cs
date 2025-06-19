using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetDurationMinutes() / 60.0);
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }
}