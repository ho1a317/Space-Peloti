using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuLevel, menuShop, menuSettings;

    public void PlayeGame()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("LastCompletedLevel", 0); // Получаем последний пройденный уровень
        PlayerPrefs.SetInt("SelectedLevel", lastCompletedLevel); // Сохраняем выбранный уровень
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene"); // Загружаем сцену Game
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

    public void ExitMenu()
    {
        menuLevel.SetActive(false);
        menuShop.SetActive(false);
        menuSettings.SetActive(false);
    }
}
