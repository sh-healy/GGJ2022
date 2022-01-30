using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private Animator _anim;

    protected void Start ()
    {
        _anim = GetComponentInChildren<Animator>();
        // _sr = GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>(); 
    }

    public void AttemptMove(float horizontal, float vertical, float moveSpeed)
    {
        _rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        
        _movement.x = horizontal;
        _movement.y = vertical;

        if(_anim != null)
        {
            _anim.SetFloat("Horizontal", horizontal);
            _anim.SetFloat("Vertical", vertical);
            _anim.SetFloat("Speed", _movement.sqrMagnitude);
        }
    }

    public void FlipSprite()
    {

    }

    
}
