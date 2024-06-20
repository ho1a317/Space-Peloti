using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel; // Панель победы
    public GameObject losePanel; // Панель поражения
    public Text timerText;

    void Start()
    {
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
        //Time.timeScale = 1; // Возвращаем нормальное время
        //СДЕЛАТЬ СИСТЕМУ ПЕРЕХОДА ИЛИ ОТКРЫТИЯ NEW LEVLE
        Debug.Log("Next Levle : 2");
        //timerText.enabled = true;
    }

    public void RetryLevel()
    {
        //Time.timeScale = 1; // Возвращаем нормальное время
      //Переделать?
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузка уровня
        // timerText.enabled = true;
        Debug.Log("RetryLevel");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1; // Возвращаем нормальное время
        SceneManager.LoadScene("MenuScene"); // Переход в меню (замените на имя вашей сцены)
    }
}