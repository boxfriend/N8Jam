using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : PlayerStateManager
{

    public static PlayerController instance;

    public LayerMask jumpMask;
    public int speed = 3;
    public float fireDelay;
    public Transform castPoint, firePoint;
    
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

    

    public void SetAnimState(bool t)
    {
        anim.SetBool("Grounded", t);
        
    }

    public void FireAnim(bool t, float dir)
    {
        anim.SetBool("Fire", t);
        anim.SetFloat("FireDir", dir);
    }

    public void MoveAnim(float x)
    {
        anim.SetFloat("X", x);
    }

    public void SetText(string _str)
    {
        dialog.text = _str;
    }

    public void PlayerPause()
    {
        SetState(new PlayerStatePause(body));
    }

    public void PlayerPrevState()
    {
        SetState(prevState);
    }
}
