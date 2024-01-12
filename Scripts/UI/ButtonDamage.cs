using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Burst.CompilerServices;

public class ButtonDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private void OnButtonClickDamage()
    {
        int damage = 10;
        _playerHealth.TakeDamage(damage);
    }
}