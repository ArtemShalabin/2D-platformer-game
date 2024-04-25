using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _sp;
    private Rigidbody2D _rb;
    private Animator _animator;
    public Animator Animator => _animator;
    [SerializeField]
    private Vector3 rayPoint;
    [SerializeField]
    private Vector2 groundCheckSize;
    [SerializeField]
    private LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("Speed", Math.Abs(Mathf.RoundToInt(Input.GetAxis("Horizontal"))));
        if(Input.GetKeyDown(KeyCode.D))
        {
            _sp.flipX = false;
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _sp.flipX = true;

        }
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
        
    }
    public bool IsGrounded()
    {
        bool isGround = Physics2D.OverlapCapsule(rayPoint + transform.position, groundCheckSize,CapsuleDirection2D.Vertical,0, whatIsGround);
        return isGround;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rayPoint + transform.position, new Vector3(groundCheckSize.x,groundCheckSize.y,0));
    }
}