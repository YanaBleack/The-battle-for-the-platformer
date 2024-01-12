using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        _playerHealth.HealthChanged += OnHealthCanged;
    }

    private void OnDisable()
    {
        _playerHealth.HealthChanged -= OnHealthCanged;
    }

    private void OnHealthCanged(int health)
    {
        _healthDisplay.text = "Hp:" + health.ToString() + "/" + _playerHealth.MaxHealth;
    }
}