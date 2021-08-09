using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI trophyCounter, trophyDialog;
    // Start is called before the first frame update
    void Start()
    {

        int trophies = GameController.instance.GetTrophies();
        trophyCounter.text = trophies.ToString();

        float total = GameController.instance.TotalTrophies();
        if (trophies == total)
        {
            trophyDialog.text = "~ i have all trophies";
        } else if (0.75f < (trophies / total)  && (trophies / total) <= 0.99f)
        {
            trophyDialog.text = "~ oooh almost there";
        } else if (0.75f >= (trophies / total) && (trophies / total) > 0.5f)
        {
            trophyDialog.text = "~ i have a bunch of these";
        } else
        {
            trophyDialog.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
