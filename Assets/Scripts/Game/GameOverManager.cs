using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public Text timerText;

    private LevelManager levelManager;
    private Spawner spawner;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        spawner = FindObjectOfType<Spawner>();

        losePanel.SetActive(false);
        winPanel.SetActive(false);

        timerText.enabled = true;
    }

    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);

        if (spawner != null)
        {
            spawner.DestroyAllObjects();
        }

        timerText.enabled = false;
    }

    public void Win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);

        if (spawner != null)
        {
            spawner.DestroyAllObjects();
        }

        timerText.enabled = false;
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        levelManager.NextLevel();

        winPanel.SetActive(false);
        timerText.enabled = true;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1;
        levelManager.RestartLevel();

        losePanel.SetActive(false);
        timerText.enabled = true;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

}
