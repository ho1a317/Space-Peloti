using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels; // Массив уровней
    private int currentLevel = 0; // Индекс текущего уровня

    private Heartsystem heartSystem;
    private Spawner spawner;
    private ControllerPlayer controllerPlayer;

    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        //spawner = FindObjectOfType<Spawner>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
        LoadLevel(currentLevel); // Загружаем первый уровень
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Length)
        {
            Debug.LogError("Invalid level index");
            return;
        }

        // Деактивируем все уровни
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }

        // Активируем нужный уровень
        levels[levelIndex].SetActive(true);
        currentLevel = levelIndex;

        Debug.Log("Level " + levelIndex + " loaded");

        //// Восстанавливаем здоровье
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
           // SaveProgress(nextLevel); // Сохраняем прогресс
        }
        else
        {
            Debug.Log("All levels completed");
            // Реализовать логику конца игры или возвращение в меню
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting level"); // Отладочное сообщение
        LoadLevel(currentLevel);
    }

    //private void SaveProgress(int levelIndex)
    //{
    //    PlayerPrefs.SetInt("LastCompletedLevel", levelIndex);
    //    PlayerPrefs.Save();
    //}

    //public int GetLastCompletedLevel()
    //{
    //    return PlayerPrefs.GetInt("LastCompletedLevel", 0); // По умолчанию 0 (первый уровень)
    //}
}
