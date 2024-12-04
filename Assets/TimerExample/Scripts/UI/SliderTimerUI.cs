using UnityEngine.UI;
using UnityEngine;
using System;

public class SliderTimerUI : IDisposable
{
    private IReadOnlyTimer _timer;

    private Slider _sliderUI;

    public SliderTimerUI(IReadOnlyTimer timer, Slider sliderUI)
    {
        _timer = timer;
        _sliderUI = sliderUI;

        _timer.Reseted += OnTimerReseted;
        _timer.Finished += OnTimerFinished;
    }

    public void Update()
    {
        if (_timer.IsRunning == false)
            return;

        float tempValue = _timer.TimeRemaining / _timer.StartTime;
        _sliderUI.value = tempValue;
    }

    public void Dispose()
    {
        _timer.Reseted -= OnTimerReseted;
        _timer.Finished -= OnTimerFinished;
    }

    public void ShowView() => _sliderUI.gameObject.SetActive(true);

    private void OnTimerReseted(float timeReset)
    {
        float tempValue = _timer.TimeRemaining / _timer.StartTime;
        _sliderUI.value = tempValue;
    }

    private void OnTimerFinished() => Debug.Log("Slider Timer Finished! :)");
}
