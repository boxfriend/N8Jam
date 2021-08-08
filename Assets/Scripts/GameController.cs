using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int trophyCount;
    private int level;

    private bool paused;
    [SerializeField] private int preLevelScenes;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        Time.timeScale = 1;
        trophyCount = PlayerPrefs.GetInt("Trophies", 0);
        level = PlayerPrefs.GetInt("Level", 1);
    }

    public int GetTrophies()
    {
        trophyCount = PlayerPrefs.GetInt("Trophies");
        return trophyCount;
    }
    public void UpdateTrophies(int change)
    {
        trophyCount = GetTrophies() + change;
        PlayerPrefs.SetInt("Trophies", trophyCount);
    }

    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(level + preLevelScenes, LoadSceneMode.Single);
    }

    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            PlayerController.instance.PlayerPause();
            SceneManager.LoadSceneAsync("Pause", LoadSceneMode.Additive);
        } else
        {
            Time.timeScale = 1;
            PlayerController.instance.PlayerPrevState();
            SceneManager.UnloadSceneAsync("Pause");
        }
    }
}
