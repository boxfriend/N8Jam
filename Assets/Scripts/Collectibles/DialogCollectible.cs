using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCollectible : MonoBehaviour
{

    [SerializeField] private string[] texts;
    [SerializeField] private bool destroyOnDone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartDialog());
        }
    }

    IEnumerator StartDialog()
    {
        foreach(string s in texts)
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(PlayerController.instance.txtDelay);
        }
        PlayerController.instance.SetText("");

        if (destroyOnDone)
        {
            Destroy(gameObject);
        }
    }
}
