using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator _animator; 
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange =0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackRate = 2f;

    private float _nextAttackTime = 0f;

    private void Update()
    {
        if(Time.time >= _nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Melee();
                _nextAttackTime = Time.time +1f / _attackRate;
            }
        }

        if (Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Shoot();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }

    private void Melee()
    {
       _animator.SetTrigger(PlayerAnimatorData.Params.Melee);

     Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemis)
        {
            Debug.Log("Óהאנ םמזמל!" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);         
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Shoot);

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemis)
        {
            Debug.Log("Âûסענוכ!" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}