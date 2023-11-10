using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private Player _player;

    private void Start()
    {
        StartCoroutine(AppearIn());
    }

    private IEnumerator AppearIn()
    {
        yield return new WaitForSeconds(1f);
        var enemy = Instantiate(_enemyMove, transform.position, Quaternion.identity);
        enemy.SetTargetPoint(_targetPoint.position);
        var enemyStalking = enemy.GetComponent<EnemyStalking>();
        enemyStalking.SetPlayer(_player.transform);
    }
}