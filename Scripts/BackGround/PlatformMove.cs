using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    private Vector2 _targetPos;

    private void Start()
    {
        _targetPos = _endPoint.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _startPoint.position) < 1f) _targetPos = _endPoint.position;

        if (Vector2.Distance(transform.position, _endPoint.position) < 1f) _targetPos = _startPoint.position;

        transform.position = Vector2.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            collision.transform.SetParent(null);
        }
    }
}
