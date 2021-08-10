using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AChoiceIsMade : MonoBehaviour
{

    [SerializeField] private GameObject[] otherChoice;
    [SerializeField] private TextMeshProUGUI thisText;
    [SerializeField] private Color color;
    [SerializeField] private int choice;
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
            PlayerController.instance.gameObject.transform.position = this.transform.position;
            StartCoroutine(ChoiceMade());
        }
    }

    IEnumerator ChoiceMade()
    {
        PlayerController.instance.PlayerPause();
        thisText.color = color;
        foreach(GameObject go in otherChoice)
        {
            Destroy(go);
            yield return new WaitForSeconds(0.75f);
        }
        TheFinalChoice.instance.MakeChoice(choice);
        Destroy(gameObject);
    }
}
