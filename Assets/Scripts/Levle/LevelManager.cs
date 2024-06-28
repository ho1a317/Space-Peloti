using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    private int currentLevel = 0;

    public GameObject player;

    private Heartsystem heartSystem;
    private ControllerPlayer controllerPlayer;

    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();

        currentLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int levelIndex)
    {
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }

        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            levels[levelIndex].SetActive(true);
            currentLevel = levelIndex;
        }
        else
        {
            Debug.LogError("Invalid level index: " + levelIndex);
            return;
        }

        MovePlayerToStart();

        if (controllerPlayer != null)
        {
            controllerPlayer.ResetHealth();
        }

        Timer timer = levels[levelIndex].GetComponentInChildren<Timer>();
        if (timer != null)
        {
            timer.RestartTimer();
        }
    }

    void MovePlayerToStart()
    {
        GameObject start = GameObject.Find("PlayerStart");
        if (start != null && player != null)
        {
            player.transform.position = start.transform.position;
        }
        else
        {
            Debug.LogError("Player or PlayerStart not found!");
        }
    }

    public void NextLevel()
    {
        int nextLevel = currentLevel + 1;
        if (nextLevel < levels.Length)
        {
            LoadLevel(nextLevel);
            SaveProgress(nextLevel);
        }
        else
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        LoadLevel(currentLevel);
    }

    private void SaveProgress(int levelIndex)
    {
        PlayerPrefs.SetInt("LastCompletedLevel", levelIndex);
        PlayerPrefs.Save();
    }

    public int GetLastCompletedLevel()
    {
        return PlayerPrefs.GetInt("LastCompletedLevel", 0);
    }
}
