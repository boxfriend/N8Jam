using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateJump : PlayerState
{
    public PlayerStateJump(Rigidbody2D _body) : base(_body)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Jump State Entered");
        yield break;
    }

    public override void FixedUpdate()
    {
        //body.MovePosition(body.position + moveDir * PlayerController.instance.speed/2 * Time.deltaTime);
    }

    public override void OnJump()
    {

    }

    public override void OnMove(InputValue value)
    {
        base.OnMove(value);
    }

    

    public override void Update()
    {
        base.Update();
    }
}
