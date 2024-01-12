using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField]  private EnemyHealth _enemyHealth;

    private void OnEnable()
    {
        _enemyHealth.DamageTaken += OnAnimatotChanged;
    }

    private void OnDisable()
    {
        _enemyHealth.DamageTaken -= OnAnimatotChanged;
    }

    private void OnAnimatotChanged()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Attack);
    }
}