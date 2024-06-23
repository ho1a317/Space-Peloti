using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels; // ������ �������
    private int currentLevel = 0; // ������ �������� ������

    public GameObject player; // ������ �� ������

    private Heartsystem heartSystem;
    private ControllerPlayer controllerPlayer;
    private Timer timer; // ��������� ���������� ��� �������


    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
        timer = FindObjectOfType<Timer>(); // �������������� ������
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
        // ���������� ������ � ��������� �����
        MovePlayerToStart();

        Debug.Log("Level " + levelIndex + " loaded");

        //// ��������������� ��������
        if (controllerPlayer != null)
        {
            Debug.Log("Resetting player health");
            controllerPlayer.ResetHealth();
        }
        // ���������� �������
        if (timer != null)
        {
            Debug.Log("TAIMERRRERRR");
            timer.RestartTimer();
        }

    }

    void MovePlayerToStart()
    {
        GameObject start = GameObject.Find("PlayerStart"); // ������� GameObject ��������� �����
        if (start != null && player != null)
        {
            player.transform.position = start.transform.position; // ���������� ������ � ��� �����
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
