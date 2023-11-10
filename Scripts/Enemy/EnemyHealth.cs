using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] int _maxHealth;

    int currentHealth;

    private void Start()
    {
        currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        _animator.SetTrigger(EnemyAnimatorData.Params.Attack);

        if (currentHealth <= 0)
        {
            Die();         
        }
    }

    private void Die()
    {
        Debug.Log("Умер!");
        Destroy(gameObject);      
    }
}