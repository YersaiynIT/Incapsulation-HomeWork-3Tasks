using System;

public interface IReadOnlyTimer
{
    event Action<float> Reseted;
    event Action Finished;

    public float StartTime { get; }
    public float TimeRemaining { get; }

    public bool IsRunning { get; }
}
