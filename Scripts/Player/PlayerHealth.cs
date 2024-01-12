using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] int _maxHealth;
  
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged; 
    public event UnityAction ButtonClickHeal; 
    public event UnityAction ButtonClickDamage;
    public event UnityAction Dead;

    public void TakeDamage(int damage)
    {       
        _health -= damage;
        if(_health <= 0)
            _health = 0;
      
        HealthChanged?.Invoke(_health);
        ButtonClickDamage?.Invoke(); 
       
        if (_health <= 0)
                 Die();       
    }

    public void SetHealth(int bonusHealth)
    {     
        _health += bonusHealth; 
       
        if (_health > _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
        ButtonClickHeal?.Invoke();
    }

    private void Die()
    {
        Dead.Invoke();        
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }
}