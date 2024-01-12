using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Slider _slider;
 
    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int health)
    {
        _slider.value = (float)health / _playerHealth.MaxHealth;
    }
}