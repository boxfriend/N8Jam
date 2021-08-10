using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessPickup : MonoBehaviour
{
    private Collider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            box.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
