using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterChanged += ShowCount;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= ShowCount;
    }

    private void ShowCount()
    {
        _text.text = _counter.Timer.ToString("");
    }
}
