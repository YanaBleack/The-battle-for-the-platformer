using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Transform _vampAttackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _timeAction;

    private float _delayTime = 1f;
    private bool _isActive;

    public void StartVampirismAbility()
    {
        StartCoroutine(RunAsync());
    }

    private IEnumerator RunAsync()
    {
        if (_isActive)
            yield break;

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(_vampAttackPoint.position, _attackRange, _enemyLayers);

        WaitForSeconds delay = new WaitForSeconds(_delayTime);

        for (int i = 0; i < _timeAction; i++)
        {
            foreach (Collider2D enemy in hitEnemis)
            {
                Debug.Log("Вампирит");
                enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);
                GetComponent<PlayerHealth>().SetHealth(_attackDamage);
            }

            yield return delay;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_vampAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(_vampAttackPoint.position, _attackRange);
    }
}