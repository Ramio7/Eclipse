using System;
using UnityEngine;
using UnityEngine.UI;

public class TestBehaviour : MonoBehaviour
{
    //private GameTimerFactory _gameTimerFactory;

    //private Button _startTimerButton;

    //void Start()
    //{
    //    _gameTimerFactory = new(DateTime.Now);
    //    _startTimerButton = GetComponentInChildren<Button>();
    //    _startTimerButton.onClick.AddListener(AddTestTimer);
    //}

    //void Update()
    //{
    //    if (_gameTimerFactory.TimerList.IsEmpty) return;
    //    else
    //    {
    //        int timerTotal = _gameTimerFactory.TimerList.Length;
    //        for (int i = 0; i < timerTotal; i++)
    //        {
    //            _gameTimerFactory.Execute(i);
    //            Debug.Log($"Timer #{i} is executed");
    //        }
    //    }
    //}

    //private void AddTestTimer() => _gameTimerFactory.AddTimer(5000);

    //private void OnDestroy()
    //{
    //    _gameTimerFactory.Dispose();
    //    _startTimerButton.onClick.RemoveListener(AddTestTimer);
    //}
}
