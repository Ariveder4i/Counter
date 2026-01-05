using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _counter = 0;

    private bool _isEnable = false;

    private Coroutine _coroutine = null;

    public event Action CounterChanged;

    public int Timer { get { return _counter; } }

    private void Start()
    {
        _coroutine = StartCoroutine(UpdateCounter(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isEnable = !_isEnable;
        }

        if (_isEnable && _coroutine == null)
        {
            _coroutine = StartCoroutine(UpdateCounter(_delay));
        }
        else if (!_isEnable && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void ChangeCounter()
    {
        _counter++;
        CounterChanged?.Invoke();
    }

    private IEnumerator UpdateCounter(float _delay)
    {
        var wait = new WaitForSeconds(_delay);

        while (_isEnable)
        {
            ChangeCounter();
            yield return wait;
        }
    }
}
