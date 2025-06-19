using System;

public class SimpleGoal : Goal
{
    private bool _goalCompleted;

    public SimpleGoal(string title, string summary, int pointValue) 
        : base(title, summary, pointValue)
    {
        _goalCompleted = false;
    }

    public SimpleGoal(string title, string summary, int pointValue, bool completed) 
        : base(title, summary, pointValue)
    {
        _goalCompleted = completed;
    }

    public override void RecordEvent()
    {
        _goalCompleted = true;
    }

    public override bool IsComplete() => _goalCompleted;

    public override string GetStringRepresentation() =>
        $"SimpleGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_goalCompleted}";
}