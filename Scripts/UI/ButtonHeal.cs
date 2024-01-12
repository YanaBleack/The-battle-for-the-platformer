using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Burst.CompilerServices;

public class ButtonHeal : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    private void OnButtonClickHealth()
    {
        int heal = 15;
        _playerHealth.SetHealth(heal);
    }  
}