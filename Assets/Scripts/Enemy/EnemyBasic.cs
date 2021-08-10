using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBasic : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private string[] texts;

    private BoxCollider2D col;
    private SpriteRenderer spr;
    private AIPath ai;
    private AIDestinationSetter target;


    private bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        ai = GetComponent<AIPath>();
        target = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Die()
    {
        alive = false;
        ai.enabled = false;
        spr.color = Color.white;
        //col.enabled = false;
        //Destroy(gameObject);
        yield break;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (alive)
            {
                StartCoroutine(PlayerController.instance.PlayerDeath());
            } else
            {
                StartCoroutine(Messages());
            }

        }

        if (collision.gameObject.CompareTag("PlayerBullet") && alive)
        {
            health--;

            if(health <= 0)
            {
                StartCoroutine(Die());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target.target = collision.gameObject.transform;
        }
    }

    private IEnumerator Messages()
    {
        foreach(string s in texts)
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(PlayerController.instance.txtDelay);
        }
    }
}
