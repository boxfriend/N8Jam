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
    public Transform castPoint, firePoint, spawnPoint;
    
    public Vector2 vel;
    public GameObject boolet;
    public float range;

    public float txtDelay;

    private bool godMode = false;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI dialog;
    [SerializeField] private string[] deathMessages;

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

    public IEnumerator PlayerDeath()
    {
        if (!godMode)
        {
            PlayerPause();
            anim.SetFloat("X", 0);
            anim.SetBool("Grounded", true);
            anim.SetBool("Fire", false);
            transform.position = spawnPoint.position;
            yield return new WaitForSeconds(1f);
            foreach (string s in deathMessages)
            {
                SetText(s);
                yield return new WaitForSeconds(txtDelay);
            }
            SetText("");
            PlayerPrevState();
        }
    }

    public IEnumerator PlayerDeathBypass()
    {
        PlayerPause();
        anim.SetFloat("X", 0);
        anim.SetBool("Grounded", true);
        anim.SetBool("Fire", false);
        transform.position = spawnPoint.position;
        yield return new WaitForSeconds(1f);
        foreach (string s in deathMessages)
        {
            SetText(s);
            yield return new WaitForSeconds(txtDelay);
        }
        SetText("");
        PlayerPrevState();
    }

    public void ToggleGodMode()
    {
        godMode = !godMode;

        if (godMode)
        {
            StartCoroutine(PrivateDialog("~ god mode?"));
        }
    }

    private IEnumerator PrivateDialog(string s)
    {
        SetText(s);
        yield return new WaitForSeconds(txtDelay);
        SetText("");
    }

    public void DebugIsActive()
    {
        StartCoroutine(PrivateDialog("~ i have admin privs?"));
    }
}
