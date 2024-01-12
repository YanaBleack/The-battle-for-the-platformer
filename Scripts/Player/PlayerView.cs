using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerCombat _playerCombat;

    private void OnEnable()
    {
        _playerHealth.Dead += OnAnimatotDied;
        _playerCombat.MeleeHit += OnAnimatorMelee;
        _playerCombat.ShootHit += OnAnimatorShoot;
    }

    private void OnDisable()
    {
        _playerHealth.Dead -= OnAnimatotDied;
        _playerCombat.MeleeHit -= OnAnimatorMelee;
        _playerCombat.ShootHit -= OnAnimatorShoot;
    }

    private void OnAnimatotDied()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.IsDead);
    }

    private void OnAnimatorMelee()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Melee);
    }

    private void OnAnimatorShoot()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Shoot);
    }
}