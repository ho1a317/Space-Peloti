using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuLevel, menuShop, menuSettings , menuIngame;

    public void PlayeGame()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("LastCompletedLevel", 0);
        PlayerPrefs.SetInt("SelectedLevel", lastCompletedLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMenuLevel()
    {
        menuLevel.SetActive(true);
    }

    public void OpenMenuShop()
    {
        menuShop.SetActive(true);
    }

    public void OpenMenuSettings()
    {
        menuSettings.SetActive(true);
    }

    public void OpenMenuIngame()
    {
        menuIngame.SetActive(true);
    }

    public void ExitMenu()
    {
        menuLevel.SetActive(false);
        menuShop.SetActive(false);
        menuSettings.SetActive(false);
        menuIngame.SetActive(false);
    }
}
