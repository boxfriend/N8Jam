using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrophyController : MonoBehaviour
{
    private CapsuleCollider2D box;
    [SerializeField] private float delay;
    [SerializeField] string[] texts;
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
            int trophy = PlayerPrefs.GetInt("Trophies", 0);
            trophy++;
            PlayerPrefs.SetInt("Trophies", trophy);
            StartCoroutine(CongratsText());
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private IEnumerator CongratsText()
    {
        box.enabled = false;

        foreach (string s in texts) 
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(delay);
        }
        Destroy(gameObject);
    }
}
