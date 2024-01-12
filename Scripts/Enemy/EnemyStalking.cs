using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStalking : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private float _speed;
    [SerializeField] private float _agroDistance;

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distToPlayer <= _agroDistance)
        {
            Debug.Log("Начал преслодовать!");
            _enemyMove.DisablePatrol();
            Hunt();
        }
        else
        {
            Debug.Log("Закончил преслодовать!");
            _enemyMove.ActivaetPatrol();
        }
    }

    private void Hunt()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}