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
        RaycastHit2D ray = BoxCast(PlayerController.instance.castPoint.position, new Vector2(0.5f, 0.5f), 0f, Vector2.down, 0.1f, PlayerController.instance.jumpMask);
        if (body.velocity.y <= 0 && ray)
        {
            isGrounded = true;
            PlayerController.instance.SetAnimState(true);
            if (dropDown == 0)
            {
                body.gameObject.layer = 6;
            }
        }
        else if (!ray)
        {
            isGrounded = false;
            PlayerController.instance.SetAnimState(false);
            body.gameObject.layer = 7;
        }
    }

    public virtual void FixedUpdate()
    {
        body.velocity = new Vector2(moveDir * PlayerController.instance.speed, body.velocity.y);

        if (dropDown != 0)
        {
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
        {
            isGrounded = false;
            body.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            PlayerController.instance.SetAnimState(true);
        }
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

    public virtual void OnDebug()
    {
        try
        {
            GameController.instance.ToggleDebug();
        }
        catch (System.NullReferenceException)
        {
            Debug.LogWarning("GameController not active in hierarchy");
        }
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

    public RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int mask)
    {
        RaycastHit2D hit = Physics2D.BoxCast(origin, size, angle, direction, distance, mask);

        //Setting up the points to draw the cast
        Vector2 p1, p2, p3, p4, p5, p6, p7, p8;
        float w = size.x * 0.5f;
        float h = size.y * 0.5f;
        p1 = new Vector2(-w, h);
        p2 = new Vector2(w, h);
        p3 = new Vector2(w, -h);
        p4 = new Vector2(-w, -h);

        Quaternion q = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        p1 = q * p1;
        p2 = q * p2;
        p3 = q * p3;
        p4 = q * p4;

        p1 += origin;
        p2 += origin;
        p3 += origin;
        p4 += origin;

        Vector2 realDistance = direction.normalized * distance;
        p5 = p1 + realDistance;
        p6 = p2 + realDistance;
        p7 = p3 + realDistance;
        p8 = p4 + realDistance;


        //Drawing the cast
        Color castColor = hit ? Color.green : Color.red;
        Debug.DrawLine(p1, p2, castColor);
        Debug.DrawLine(p2, p3, castColor);
        Debug.DrawLine(p3, p4, castColor);
        Debug.DrawLine(p4, p1, castColor);

        Debug.DrawLine(p5, p6, castColor);
        Debug.DrawLine(p6, p7, castColor);
        Debug.DrawLine(p7, p8, castColor);
        Debug.DrawLine(p8, p5, castColor);

        Debug.DrawLine(p1, p5, Color.grey);
        Debug.DrawLine(p2, p6, Color.grey);
        Debug.DrawLine(p3, p7, Color.grey);
        Debug.DrawLine(p4, p8, Color.grey);
        if (hit)
        {
            Debug.DrawLine(hit.point, hit.point + hit.normal.normalized * 0.2f, Color.yellow);
        }

        return hit;
    }
}
