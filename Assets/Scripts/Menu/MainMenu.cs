using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI trophyCounter, trophyDialog;

    [SerializeField] private GameObject secretPanel, nice;

    private int secretTimes = 0;
    private int trophies;

    // Start is called before the first frame update
    void Start()
    {

        UpdateTrophies();
        UpdateTxt();
    }

    void OnScenePick()
    {
        secretPanel.SetActive(!secretPanel.activeSelf);
        secretTimes++;

        if(secretTimes >= 69)
        {
            nice.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTxt()
    {
        float total = GameController.instance.TotalTrophies();
        if (trophies == total)
        {
            trophyDialog.text = "~ i have all of the trophies";
        }
        else if (0.75f < (trophies / total) && (trophies / total) <= 0.99f)
        {
            trophyDialog.text = "~ oooh almost there";
        }
        else if (0.75f >= (trophies / total) && (trophies / total) > 0.4f)
        {
            trophyDialog.text = "~ i have a bunch of these";
        }
        else if (trophies == 69)
        {
            trophyDialog.text = "~ nice";
        }
        else if (trophies == 420)
        {
            trophyDialog.text = "~ blaze it";
        }
        else if (trophies > total)
        {
            trophyDialog.text = "~ replaying levels for more trophies is cool so now i get this cool really long text on the main menu";
        }
        else
        {
            trophyDialog.text = "";
        }
    }

    private void FixedUpdate()
    {
        UpdateTrophies();
        UpdateTxt();
    }

    public void UpdateTrophies()
    {
        trophies = GameController.instance.GetTrophies();
        trophyCounter.text = trophies.ToString();
    }
}
