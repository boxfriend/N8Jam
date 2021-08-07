using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    protected PlayerState state;
    protected Rigidbody2D body;
    protected void SetState(PlayerState _state)
    {
        if (state != null)
        {
            StartCoroutine(state.Exit());
        }

        state = _state;
        StartCoroutine(state.Start());
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();
    }

    private void FixedUpdate()
    {
        state.FixedUpdate();
    }

    void OnMove(InputValue value)
    {
        state.OnMove(value);
    }

    void OnFire(InputValue value)
    {
        state.OnMove(value);
    }

    void OnJump()
    {
        state.OnJump();
    }

    void OnDown(InputValue value)
    {
        state.OnDown(value);
    }

}
