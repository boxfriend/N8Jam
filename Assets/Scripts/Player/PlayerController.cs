using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : PlayerStateManager
{

    public static PlayerController instance;

    public LayerMask jumpMask;
    public int speed = 3;
    public Transform castPoint;
    
    public Vector2 vel;
    public GameObject boolet;
    public float range;

    private Animator anim;
    [SerializeField] private TextMeshProUGUI dialog;

    private void Awake()
    {
        instance = this;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        SetState(new PlayerStateBase(body));
        dialog.text = "";
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

    public void SetText(string _str)
    {
        dialog.text = _str;
    }
}
