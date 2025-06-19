using System;

public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public int GetBonus() => _bonus;

    public CheckListGoal(string name, string description, int points, int bonus, int target, int amountCompleted = 0) 
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailString() =>
        $"{GetShortName()} ({GetDescription()}) -- Progress: {_amountCompleted}/{_target}";

    public override string GetStringRepresentation() =>
        $"CheckListGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_bonus}, {_target}, {_amountCompleted}";
}