using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOTriggerCheck : MonoBehaviour
{

    [SerializeField] private GameObject[] gameObjects, textObjects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CheckObjects());
        }
    }

    IEnumerator CheckObjects()
    {
        for(int i = 0; i < gameObjects.Length; i++)
        {
            if(gameObjects[i] != null)
            {
                textObjects[i].SetActive(true);
            }
        }
        yield break;
    }
}
