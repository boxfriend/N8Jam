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

    protected bool canFire = false;

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
        
    }

    public virtual void FixedUpdate()
    {
        body.velocity = new Vector2(moveDir * PlayerController.instance.speed, body.velocity.y);

        if (dropDown != 0)
        {
            PlayerController.instance.SetAnimState(false);
            body.gameObject.layer = 7;
        }

        RaycastHit2D ray = Physics2D.BoxCast(PlayerController.instance.castPoint.position, new Vector2(0.5f, 0.5f), 0f, Vector2.down, 0.3f, PlayerController.instance.jumpMask);

        if (ray)
        {
            isGrounded = true;
            PlayerController.instance.SetAnimState(true);
            if (dropDown == 0)
            {
                body.gameObject.layer = 6;
            }
        }
        else
        {
            isGrounded = false;
            PlayerController.instance.SetAnimState(false);
            body.gameObject.layer = 7;
        }
    }

    public virtual void OnMove(InputValue value)
    {
        moveDir = value.Get<float>();
        PlayerController.instance.MoveAnim(moveDir);
    }

    public virtual void OnJump()
    {
        if (isGrounded)
            body.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
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
            PlayerController.instance.FireAnim(true, fireDir);
            GameObject bullet = Object.Instantiate(PlayerController.instance.boolet, PlayerController.instance.firePoint.position, Quaternion.Euler(0, 0, 90)) as GameObject;
            bullet.GetComponent<BulletController>().range = PlayerController.instance.range;
            bullet.GetComponent<Rigidbody2D>().velocity = fireDir * new Vector2(5, 0);
            yield return new WaitForSeconds(PlayerController.instance.fireDelay);
            PlayerController.instance.FireAnim(false, fireDir);
            canFire = true;
        }
    }

    public virtual void OnEscape()
    {
        GameController.instance.Pause();
    }

    public virtual IEnumerator Exit()
    {
        moveDir = 0;
        body.velocity = Vector2.zero;
        yield break;
    }

    public virtual void GunGet()
    {
        canFire = true;
    }
}
