using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _horizontalMove = 0f;
    private bool _facingRight = true;

    [Header("Events")]
    [Range(0, 10f)][SerializeField] private float _speed = 1f;
    [Range(0, 15f)][SerializeField] private float _jumpForce = 8f;

    [Space]
    [Header("Ground Checker Setting")]
    public bool isGrounded = false;
    [Range(-5f, 5f)][SerializeField] private float _checkGroundOffsetY = -1.8f;
    [Range(0, 5f)][SerializeField] private float _checkGroundRadius = 0.3f; 

    private void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();      
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }

        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;
      
        _animator.SetFloat("HorizontalMove", Mathf.Abs(_horizontalMove));

        if(isGrounded == false)
        {
          _animator.SetBool(PlayerAnimatorData.Params.IsJumping, true);
        }
        else { _animator.SetBool(PlayerAnimatorData.Params.IsJumping, false); } 

        if (_horizontalMove > 0 && !_facingRight)
        {
            Flip();
        }
        else if (_horizontalMove < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y 
            + _checkGroundOffsetY), _checkGroundRadius);

        if (colliders.Length > 1)
        {
            isGrounded = true;
        }
        else { isGrounded = false; }
    }

    private void Flip()
    {       
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale; 
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}