using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange =0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackRate = 2f;
    [SerializeField] private KeyCode _melee;
    [SerializeField] private KeyCode _shoot;

    private float _nextAttackTime = 0f;

    public event UnityAction MeleeHit;
    public event UnityAction ShootHit;

    private void Update()
    {
        if(Time.time >= _nextAttackTime) 
        {
            if (Input.GetKeyDown(_melee)) 
            {
                Melee();
                _nextAttackTime = Time.time +1f / _attackRate;
            }
        }

        if (Time.time >= _nextAttackTime)
        {
            if (Input.GetKeyDown(_shoot)) 
            {
                Shoot();
                _nextAttackTime = Time.time + 1f / _attackRate;
            }
        }
    }

    private void Melee()
    {
        MeleeHit.Invoke();

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemis)
        {
            Debug.Log("Óהאנ םמזמל!" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);         
        }
    }

    private void Shoot()
    {
        ShootHit.Invoke();

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