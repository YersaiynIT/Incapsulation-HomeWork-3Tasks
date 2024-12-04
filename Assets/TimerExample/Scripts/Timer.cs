using System;
using UnityEngine;

public class Timer : IReadOnlyTimer
{
    public event Action<float> Reseted;
    public event Action Finished;

    public Timer(float startTime)
    {
        StartTime = startTime;
        TimeRemaining = startTime;

        IsRunning = false;
    }

    public float StartTime { get; }
    public float TimeRemaining { get; private set; }

    public bool IsRunning { get; private set; }

    public void Update()
    {
        if (IsRunning)
        {
            if (TimeRemaining <= 0)
            {
                Stop();
                Finished?.Invoke();

                return;
            }

            TimeRemaining -= Time.deltaTime;
        }
    }

    public void Launch() => IsRunning = true;

    public void Stop() => IsRunning = false;

    public void Reset()
    {
        TimeRemaining = StartTime;

        Reseted?.Invoke(StartTime);
    }
}
