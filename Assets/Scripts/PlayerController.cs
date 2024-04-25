using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private PlayerAnimation _playerAnimation;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Vector2 ofset;
    [SerializeField]
    private LayerMask layer;
       // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hitRite = CheckWall(transform.right);
        bool hitLeft = CheckWall(-transform.right);
        
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0 && hitRite == true) 
        {
            return;
        }
        if (horizontalInput < 0 && hitLeft == true)
        {
            return;
        }
        _rb.velocity=new Vector2(horizontalInput*speed,_rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_playerAnimation.IsGrounded() == true)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);

            }

        }
        _playerAnimation.Animator.SetBool("IsJump", _playerAnimation.IsGrounded());
    }
    private bool CheckWall(Vector2 direction)
    {
        Vector2 startPoint = new Vector2(transform.position.x, transform.position.y) + ofset;
        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, distance, layer);
        Debug.DrawRay(startPoint, direction * distance, Color.red);
        if(hit.collider == null)
        {
            return false;
        }
        else { return true; }
    }
    
}