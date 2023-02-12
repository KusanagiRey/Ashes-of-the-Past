using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{   
    private Rigidbody2D _rigidbody;
    private Vector2 _moveVector;
    private Animator _animator;
    private SpriteRenderer _sprRendered;

    [SerializeField] private float _speed;

    [SerializeField] private float _jumpForce;
    private bool _jumpLock = false;

    [SerializeField] private float _rollDistance;
    private bool _isRolling;
    private float _doubleTapTime;
    KeyCode lastKeyCode;
 
    private float _checkRadius = 0.2f;
    public bool _isGrounded;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundMask; 

    [SerializeField] private Transform TopCheck;
    [SerializeField] private LayerMask roofMask;
    [SerializeField] private Collider2D poseStand;
    [SerializeField] private Collider2D poseSquat; 
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprRendered = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Moving
        _moveVector.x = Input.GetAxisRaw("Horizontal");   
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
        _animator.SetFloat("moveX", Mathf.Abs(_moveVector.x));

        if (_moveVector.x != 0)
        {
            _sprRendered.flipX = _moveVector.x > 0 ? false : true;         
        }

        //Croaching
        if (Input.GetKey(KeyCode.LeftControl) && _isGrounded)
        {
            _animator.SetBool("isSquat", true);
            poseStand.enabled = false;
            poseSquat.enabled = true;
            _jumpLock = true;
            _speed = 2f;
        }
        else if (!Physics2D.OverlapCircle(TopCheck.position, _checkRadius, roofMask))
        {
            _animator.SetBool("isSquat", false);
            poseStand.enabled = true;
            poseSquat.enabled = false;
            _jumpLock = false;
            _speed = 4f;
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_isRolling && !_jumpLock)
        {
            Jump();
        }

        //Rolling Left
        if (Input.GetKeyDown(KeyCode.A) && _isGrounded)
        {
            if (_doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Roll(-1f));
            }
            else
            {
              _doubleTapTime = Time.time + 0.5f;  
            }
            lastKeyCode = KeyCode.A;
        }

        //Rolling Right
        if (Input.GetKeyDown(KeyCode.D) && _isGrounded)
        {
            if (_doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Roll(1f));
            }
            else
            {
              _doubleTapTime = Time.time + 0.5f;  
            }
            lastKeyCode = KeyCode.D;
        }

        CheckGround(); 
    }  

    private void Jump()
    {
        _animator.SetTrigger("Jump");
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);  
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, _checkRadius, groundMask);
        _animator.SetBool("onGround", _isGrounded);
    }

    IEnumerator Roll (float direction)
    {
        _isRolling = true;
        _animator.SetTrigger("Roll");
        _rigidbody.AddForce(new Vector2(_rollDistance * direction, _rigidbody.velocity.y), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.6f);
        _isRolling = false;
    }
}
