using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel; // ������ ������
    public GameObject losePanel; // ������ ���������
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
        //Time.timeScale = 1; // ���������� ���������� �����
        //������� ������� �������� ��� �������� NEW LEVLE
        Debug.Log("Next Levle : 2");
        //timerText.enabled = true;
    }

    public void RetryLevel()
    {
        //Time.timeScale = 1; // ���������� ���������� �����
      //����������?
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������ ������
        // timerText.enabled = true;
        Debug.Log("RetryLevel");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1; // ���������� ���������� �����
        SceneManager.LoadScene("MenuScene"); // ������� � ���� (�������� �� ��� ����� �����)
    }
}