using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 startPos;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = gameObject.transform.position;

        if (Vector3.Distance(currPos, startPos) >= range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
