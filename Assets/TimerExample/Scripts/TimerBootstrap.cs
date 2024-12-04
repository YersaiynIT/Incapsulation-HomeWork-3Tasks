using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class TimerBootstrap : MonoBehaviour
{
    [SerializeField] private TMP_Text _textUI;
    private TextTimerUI _textTimer;

    [SerializeField] private Slider _sliderUI;
    private SliderTimerUI _sliderTimer;

    [SerializeField] private Transform _heartContainerTransform;
    [SerializeField] private Heart _heartPrefab;
    private HeartTimerUI _heartTimer;

    [SerializeField] private float _startTime;
    private Timer _timer;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        _timer = new Timer(_startTime);

        _textTimer = new TextTimerUI(_timer, _textUI);
        _textTimer.ShowView();

        _sliderTimer = new SliderTimerUI(_timer, _sliderUI);
        _sliderTimer.ShowView();

        _heartTimer = new HeartTimerUI(_timer, _heartContainerTransform, _heartPrefab);
        _heartTimer.ShowView();

        _disposables.Add(_textTimer);
        _disposables.Add(_sliderTimer);
        _disposables.Add(_heartTimer);
    }

    private void Update()
    {
        _textTimer.Update();
        _sliderTimer.Update();
        _heartTimer.Update();

        _timer.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            _timer.Launch();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _timer.Stop();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _timer.Reset();
    }
}
