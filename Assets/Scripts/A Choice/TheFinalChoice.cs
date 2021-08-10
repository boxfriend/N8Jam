using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class TheFinalChoice : MonoBehaviour
{
    public static TheFinalChoice instance;

    [SerializeField] private string[] complyChoice, breakChoice;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private TextMeshProUGUI finalTxt;
    [SerializeField] private GameObject level;

    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                StartCoroutine(FinalChoice(complyChoice));
                break;
            case 2:
                PlayerController.instance.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
                finalTxt.color = Color.red;
                audioS.PlayDelayed(3f);
                StartCoroutine(FinalChoice(breakChoice));
                break;
        }
    }
    public IEnumerator FinalChoice(string[] dialogs)
    {
        foreach(string s in dialogs)
        {
            PlayerController.instance.SetText(s);
            yield return new WaitForSeconds(PlayerController.instance.txtDelay);
        }
        yield return new WaitForSeconds(3f);
        cam.Follow = gameObject.transform;
        yield return new WaitForSeconds(2f);
        Destroy(PlayerController.instance.gameObject);
        audioS.Stop();
        yield return new WaitForSeconds(2f);
        Destroy(level);
        yield return new WaitForSeconds(2f);
        finalTxt.text = "> we are not finished here . . .";
    }
}
