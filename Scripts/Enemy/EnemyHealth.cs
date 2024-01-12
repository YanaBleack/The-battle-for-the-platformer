using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;

    private int _stealHeal;
    public int MaxHealth => _maxHealth;
    public event UnityAction<int> HealthChanged;
   
    public event UnityAction DamageTaken;

    public int TakeDamage(int damage)
    {
        _health -= damage; 
       
        HealthChanged?.Invoke(_health);      
        DamageTaken.Invoke();

        if (_health <= 0)
        {
            Die();
        }
        Debug.Log("Враг теряет hp");
        return _health;
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }
}