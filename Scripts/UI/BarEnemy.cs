using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BarEnemy : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
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
        _slider.maxValue = _enemyHealth.MaxHealth;
    }

    private void OnEnable()
    {
        _enemyHealth.HealthChanged += OnHealthsChanged;
    }

    private void OnDisable()
    {
        _enemyHealth.HealthChanged -= OnHealthsChanged;
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