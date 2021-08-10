using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fpsCounter, memtext, lvlCount, trophyCount;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject gmToggle;

    private float current;
    // Start is called before the first frame update
    void Start()
    {
        canvas.worldCamera = Camera.main;

        try
        {
            lvlCount.text = "LVL: " + GameController.instance.GetLvl();

            if (GameController.instance.GetLvl() >= 4)
                gmToggle.SetActive(true);
        }
        catch (System.NullReferenceException)
        {
            Debug.Log("GameController not active in hierarchy");
            lvlCount.text = "LVL: ?";
        }

        GameObject.FindWithTag("LevelController").GetComponent<LevelController>().DebugActive();

    }

    // Update is called once per frame
    void Update()
    {
        current = (int)(1f / Time.unscaledDeltaTime);

        memtext.text = "MEM: " + FormatBytes(System.GC.GetTotalMemory(false));
    }

    private void FixedUpdate()
    {
        fpsCounter.text = "FPS: " + current;

        try
        {
            trophyCount.text = "Trophies: " + GameController.instance.GetTrophies();
        }
        catch (System.NullReferenceException)
        {
            trophyCount.text = "Trophies: ?";
        }
    }

    private static string FormatBytes(long bytes)
    {
        string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
        int i;
        double dblSByte = bytes;
        for (i = 0; i < Suffix.Length && bytes >= 1000; i++, bytes /= 1000)
        {
            dblSByte = bytes / 1000.0;
        }

        return System.String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
    }

    public void ToggleGodMode()
    {
        PlayerController.instance.ToggleGodMode();
    }
}
