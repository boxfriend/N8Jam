using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugReportController : MonoBehaviour
{

    [SerializeField] private string[] texts;
    private BoxCollider2D box;
    private SpriteRenderer spr;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Collected());
        }
    }

    private IEnumerator Collected()
    {
        box.enabled = false;
        spr.enabled = false;
        foreach (string s in texts)
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(PlayerController.instance.txtDelay);
        }

        try
        {
            GameController.instance.NextLevel();
        } catch(System.NullReferenceException)
        {
            Debug.LogWarning("GameController Not Active in Hierarchy");
        }
    }
}
