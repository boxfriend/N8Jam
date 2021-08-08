using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatePause : PlayerState
{
    public PlayerStatePause(Rigidbody2D body) : base(body)
    {

    }

    public override IEnumerator Exit()
    {
        yield break;
    }

    public override void FixedUpdate()
    {
        
    }

    public override void OnDown(InputValue value)
    {
        
    }

    public override void OnEscape()
    {
        base.OnEscape();
    }

    public override IEnumerator OnFire(float fireDir)
    {
        yield break;
    }

    public override void OnJump()
    {
        
    }

    public override void OnMove(InputValue value)
    {
        
    }

    public override IEnumerator Start()
    {
        yield break;
    }

    public override void Update()
    {
        
    }
}
