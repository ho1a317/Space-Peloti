using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Установите нужное время
    public Text timerText; // Перетащите сюда текстовый UI элемент

    private GameOverManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameOverManager>();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            gameManager.Win();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:0}:{1:0}", minutes, seconds);
    }
}