using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState
{
    protected Rigidbody2D body;
    protected float moveDir;
    protected float dropDown;

    protected bool isGrounded = true;

    public PlayerState(Rigidbody2D _body)
    {
        body = _body;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        PlayerController.instance.SetAnimState(body.velocity);
    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void OnMove(InputValue value)
    {
        moveDir = value.Get<float>();
    }

    public virtual void OnJump()
    {

    }

    public virtual void OnDown(InputValue value)
    {
        dropDown = value.Get<float>();
    }

    public virtual void OnFire(InputValue value)
    {

    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
