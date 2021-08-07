using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerStateManager
{

    public static PlayerController instance;

    public LayerMask jumpMask;
    public int speed = 3;

    public Transform castPoint;

    private Animator anim;

    public Vector2 vel;

    private void Awake()
    {
        instance = this;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        SetState(new PlayerStateBase(body));
    }

    public void Jump()
    {
        SetState(new PlayerStateJump(body));
    }

    public void SetAnimState(Vector2 velocity)
    {
        anim.SetFloat("X", velocity.x);
        anim.SetFloat("Y", velocity.y);

        vel = velocity;
    }


}
