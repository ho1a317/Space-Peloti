using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject winPanel; // Панель победы
    public GameObject losePanel; // Панель поражения
    public Text timerText;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        
        losePanel.SetActive(false);
        winPanel.SetActive(false);

        timerText.enabled = true;

    }

    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);

        timerText.enabled = false;
    }

    public void Win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);

        timerText.enabled = false;
    }

    public void NextLevel()
    {
        Time.timeScale = 1; // Возвращаем нормальное время
        levelManager.NextLevel(); // Переход на следующий уровень

        winPanel.SetActive(false);
        timerText.enabled = true;

    }

    public void RetryLevel()
    {
        Time.timeScale = 1; // Возвращаем нормальное время
        levelManager.RestartLevel(); // Перезагрузка текущего уровня
        
        losePanel.SetActive(false);
        timerText.enabled = true;

    }

    public void GoToMenu()
    {
        Time.timeScale = 1; // Возвращаем нормальное время
        SceneManager.LoadScene("MenuScene"); // Переход в меню (замените на имя вашей сцены)
    }
}