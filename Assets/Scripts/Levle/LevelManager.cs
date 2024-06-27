using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels; // Массив уровней
    private int currentLevel = 0; // Индекс текущего уровня

    public GameObject player; // Ссылка на игрока

    private Heartsystem heartSystem;
    private ControllerPlayer controllerPlayer;

    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();

        // Загружаем выбранный уровень из PlayerPrefs
        currentLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int levelIndex)
    {
        // Деактивируем все уровни
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }

        // Активируем нужный уровень
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

        // Перемещаем игрока в стартовую точку
        MovePlayerToStart();

        // Восстанавливаем здоровье
        if (controllerPlayer != null)
        {
            controllerPlayer.ResetHealth();
        }

        // Перезапуск таймера
        Timer timer = levels[levelIndex].GetComponentInChildren<Timer>();
        if (timer != null)
        {
            timer.RestartTimer();
        }
    }

    void MovePlayerToStart()
    {
        GameObject start = GameObject.Find("PlayerStart"); // Находим GameObject стартовой точки
        if (start != null && player != null)
        {
            player.transform.position = start.transform.position; // Перемещаем игрока в эту точку
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
            SaveProgress(nextLevel); // Сохраняем прогресс
        }
        else
        {
            Debug.Log("All levels completed");
            // Реализовать логику конца игры или возвращение в меню
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
        return PlayerPrefs.GetInt("LastCompletedLevel", 0); // По умолчанию 0 (первый уровень)
    }
}
