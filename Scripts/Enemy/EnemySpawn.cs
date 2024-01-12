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
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        EnemyMove enemy = Instantiate(_enemyMove, transform.position, Quaternion.identity);
        enemy.SetTargetPoint(_targetPoint.position);
      
        var enemyStalking = enemy.GetComponent<EnemyStalking>();
        enemyStalking.SetPlayer(_player.transform);
    }
}