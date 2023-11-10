using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _targetPoint;
    private Vector2 _startPoint;
    private Vector2 _curentPoint;
    private bool _isPatrol = true;

    public void ActivaetPatrol()
    {
        _isPatrol = true;
    }

    public void DisablePatrol()
    {
        _isPatrol = false;
    }

    public void SetTargetPoint(Vector2 target)
    {
        _targetPoint = target;
    }

    private void Start()
    {
        Debug.Log("Враг появился!");
        _startPoint = transform.position;
    }

    private void Update()
    {
        if (_isPatrol)
        {
            transform.position = Vector2.MoveTowards(transform.position, _curentPoint, 0.1f * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out TargetPoint targetPoint))
        {
            _curentPoint = _startPoint;
            Debug.Log("Задел таргет!");
        }
        else if (collider.gameObject.TryGetComponent(out SpawnerPoint spawnerPoint))
        {
            _curentPoint = _targetPoint;
            Debug.Log("Задел старт!");
        }
    }
}