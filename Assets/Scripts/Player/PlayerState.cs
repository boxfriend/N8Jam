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

    protected bool canFire = true;

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

    public virtual IEnumerator OnFire(float fireDir)
    {
        if (canFire)
        {
            canFire = false;
            GameObject bullet = Object.Instantiate(PlayerController.instance.boolet, body.position, Quaternion.Euler(0, 0, 90)) as GameObject;
            bullet.GetComponent<BulletController>().range = PlayerController.instance.range;
            bullet.GetComponent<Rigidbody2D>().velocity = fireDir * new Vector2(5, 0);
            yield return new WaitForSeconds(0.5f);
            canFire = true;
        }
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
