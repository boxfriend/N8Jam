using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrophyController : MonoBehaviour
{
    private CapsuleCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            try
            {
                GameController.instance.UpdateTrophies(1);
            } catch(System.NullReferenceException) {
                Debug.LogWarning("GameController Not Active in Hierarchy");
            }
            box.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
