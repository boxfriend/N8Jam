using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            PlayerController.instance.SetText("~ this area is under construction");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            PlayerController.instance.SetText("");
    }
}
