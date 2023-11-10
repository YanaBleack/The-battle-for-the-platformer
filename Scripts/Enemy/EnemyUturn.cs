using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUturn : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out TargetPoint targetPoint))
        {
            _spriteRenderer.flipX = true;
        }
        else if (collider.gameObject.TryGetComponent(out SpawnerPoint spawnerPoint))
        {
            _spriteRenderer.flipX = false;
        }
    }
}