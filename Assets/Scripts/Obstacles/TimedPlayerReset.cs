using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimedPlayerReset : MonoBehaviour
{
    [SerializeField] private string[] texts;
    private TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ResetPlayer());
    }

    IEnumerator ResetPlayer()
    {
        float delay = PlayerController.instance.txtDelay;
        yield return new WaitForSeconds(delay);
        foreach(string s in texts)
        {
            txt.text = s;
            yield return new WaitForSeconds(delay);
        }
        txt.text = "";
        StartCoroutine(PlayerController.instance.PlayerDeath());
    }
}
