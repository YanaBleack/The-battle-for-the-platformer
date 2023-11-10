using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _health;
    [SerializeField] int _maxHealth;
    
    public void TakeDamage(int damage)
    {
        Debug.Log("����!");
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("���� �����!");
       _animator.SetTrigger(PlayerAnimatorData.Params.IsDead);         
    }

    public void SetHealth(int bonusHealth) 
    {
        Debug.Log("����������!");
        _health += bonusHealth;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}