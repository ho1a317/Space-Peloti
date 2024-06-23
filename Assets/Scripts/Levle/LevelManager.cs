using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels; // ������ �������
    private int currentLevel = 0; // ������ �������� ������

    private Heartsystem heartSystem;
    private Spawner spawner;
    private ControllerPlayer controllerPlayer;

    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        //spawner = FindObjectOfType<Spawner>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
        LoadLevel(currentLevel); // ��������� ������ �������
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Length)
        {
            Debug.LogError("Invalid level index");
            return;
        }

        // ������������ ��� ������
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }

        // ���������� ������ �������
        levels[levelIndex].SetActive(true);
        currentLevel = levelIndex;

        Debug.Log("Level " + levelIndex + " loaded");

        //// ��������������� ��������
        if (controllerPlayer != null)
        {
            Debug.Log("Resetting player health");
            controllerPlayer.ResetHealth();
        }

    }


    public void NextLevel()
    {
        int nextLevel = currentLevel + 1;
        if (nextLevel < levels.Length)
        {
            LoadLevel(nextLevel);
           // SaveProgress(nextLevel); // ��������� ��������
        }
        else
        {
            Debug.Log("All levels completed");
            // ����������� ������ ����� ���� ��� ����������� � ����
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting level"); // ���������� ���������
        LoadLevel(currentLevel);
    }

    //private void SaveProgress(int levelIndex)
    //{
    //    PlayerPrefs.SetInt("LastCompletedLevel", levelIndex);
    //    PlayerPrefs.Save();
    //}

    //public int GetLastCompletedLevel()
    //{
    //    return PlayerPrefs.GetInt("LastCompletedLevel", 0); // �� ��������� 0 (������ �������)
    //}
}
