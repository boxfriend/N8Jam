using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterBounds : MonoBehaviour
{
    [SerializeField] string[] texts;
    private bool isRunning = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isRunning)
        {
            StartCoroutine(BoundsText());
        }
    }

    private IEnumerator BoundsText()
    {
        isRunning = true;
        foreach (string s in texts)
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(3);
        }
        isRunning = false;
    }
}
