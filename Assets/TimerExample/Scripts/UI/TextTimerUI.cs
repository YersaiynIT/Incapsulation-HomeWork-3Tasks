using System;
using TMPro;
using UnityEngine;

public class TextTimerUI : IDisposable
{
    private IReadOnlyTimer _timer;

    private TMP_Text _timerUI;

    public TextTimerUI(IReadOnlyTimer timer, TMP_Text timerUI)
    {
        _timer = timer;
        _timerUI = timerUI;

        _timer.Reseted += OnTimerReseted;
        _timer.Finished += OnTimerFinished;

        _timerUI.text = "Timer: " + _timer.StartTime.ToString("0.00");
    }

    public void Update()
    {
        if (_timer.IsRunning == false)
            return;

        _timerUI.text = "Timer: " + _timer.TimeRemaining.ToString("0.00");
    }

    public void Dispose()
    {
        _timer.Reseted -= OnTimerReseted;
        _timer.Finished -= OnTimerFinished;
    }

    public void ShowView() => _timerUI.gameObject.SetActive(true);

    private void OnTimerReseted(float resetTime) => _timerUI.text = "Timer: " + resetTime.ToString("0.00");

    private void OnTimerFinished() => Debug.Log("Text Timer Finished! :) ");
}
