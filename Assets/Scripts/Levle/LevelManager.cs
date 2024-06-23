using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels; // Массив уровней
    private int currentLevel = 0; // Индекс текущего уровня

    public GameObject player; // Ссылка на игрока

    private Heartsystem heartSystem;
    private ControllerPlayer controllerPlayer;
    private Timer timer; // Добавляем переменную для таймера


    void Start()
    {
        heartSystem = FindObjectOfType<Heartsystem>();
        controllerPlayer = FindObjectOfType<ControllerPlayer>();
        timer = FindObjectOfType<Timer>(); // Инициализируем таймер
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
        // Перемещаем игрока в стартовую точку
        MovePlayerToStart();

        Debug.Log("Level " + levelIndex + " loaded");

        //// Восстанавливаем здоровье
        if (controllerPlayer != null)
        {
            Debug.Log("Resetting player health");
            controllerPlayer.ResetHealth();
        }
        // Перезапуск таймера
        if (timer != null)
        {
            Debug.Log("TAIMERRRERRR");
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
