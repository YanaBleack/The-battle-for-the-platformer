using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BarSmooth : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _interpolationStep;

    private Coroutine _changingValue;

    protected virtual void OnHealthsChanged(int health)
    {
        if (_changingValue != null)
        {
            StopCoroutine(_changingValue);
        }
        _changingValue = StartCoroutine(ChangingValue(health));
    }

    private void Awake()
    {
        _slider.maxValue = _playerHealth.MaxHealth;
    }

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthsChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthsChanged;
    }

    private IEnumerator ChangingValue(int targetValue)
    {
        while (enabled)
        {
            _slider.value = Mathf.Lerp(_slider.value, targetValue, _interpolationStep * Time.deltaTime);

            yield return null;
        }
    }
}