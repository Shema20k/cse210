public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;

        if (_currentCount == _targetCount)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_currentCount}/{_targetCount})";
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_shortName}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonus}";
    }

    public void SetProgress(int current)
    {
        _currentCount = current;
    }
}
