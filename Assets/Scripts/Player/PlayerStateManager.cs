using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    protected PlayerState state;
    protected PlayerState prevState;
    protected Rigidbody2D body;
    protected float fireDir;


    public bool isPassive;
    protected void SetState(PlayerState _state)
    {
        if (state != null)
        {
            prevState = state;
            StartCoroutine(state.Exit());
        }

        state = _state;
        StartCoroutine(state.Start());
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();

        if(fireDir != 0)
        {
            StartCoroutine(state.OnFire(fireDir));
        }
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
        fireDir = value.Get<float>();
    }

    void OnJump()
    {
        state.OnJump();
    }

    void OnDown(InputValue value)
    {
        state.OnDown(value);
    }

    void OnEscape()
    {
        state.OnEscape();
    }

    void OnDebug()
    {
        state.OnDebug();
    }

    public void GunGet()
    {
        state.GunGet();
        isPassive = false;
    }

}
