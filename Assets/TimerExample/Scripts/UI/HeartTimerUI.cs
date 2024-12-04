using System;
using System.Collections.Generic;
using UnityEngine;

public class HeartTimerUI : IDisposable
{
    private IReadOnlyTimer _timer;

    private Transform _heartCountainerTransform;
    private Heart _heartPrefab;
    private List<Heart> _hearts = new();

    private int _startHeartsCount;
    private float _elapsedTime = 0f;

    public HeartTimerUI(IReadOnlyTimer timer, Transform heartCountainerTransform, Heart heartPrefab)
    {
        _timer = timer;
        _heartCountainerTransform = heartCountainerTransform;
        _heartPrefab = heartPrefab;

        _timer.Reseted += OnTimerReseted;
        _timer.Finished += OnTimerFinished;

        _startHeartsCount = (int)_timer.StartTime;

        Reset();
    }

    public void Update()
    {
        if (_timer.IsRunning == false)
            return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 0.999f)
        {
            _elapsedTime = 0f;

            RemoveLastHeart();
        }
    }

    public void Dispose()
    {
        _timer.Reseted -= OnTimerReseted;
        _timer.Finished -= OnTimerFinished;
    }

    public void ShowView() => _heartCountainerTransform.gameObject.SetActive(true);

    public void RemoveLastHeart()
    {
        if (_hearts.Count > 0)
        {
            Heart heart = _hearts[_hearts.Count - 1];

            UnityEngine.Object.Destroy(heart.gameObject);
            _hearts.Remove(heart);
        }
    }

    public void Reset()
    {
        Clear();

        for (int i = 0; i < _startHeartsCount; i++)
        {
            Heart heart = UnityEngine.Object.Instantiate(_heartPrefab, _heartCountainerTransform);

            _hearts.Add(heart);
        }
    }

    private void OnTimerReseted(float resetTime)
    {
        _elapsedTime = 0f;

        Reset();
    }

    private void OnTimerFinished() => Debug.Log("Heart Timer Finished! :)");

    private void Clear()
    {
        foreach (Heart heart in _hearts)
            UnityEngine.Object.Destroy(heart.gameObject);
            
        _hearts.Clear();
    }
}
