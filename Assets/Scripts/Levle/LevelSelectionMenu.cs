using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public Button[] levelButtons; // Кнопки уровней

    void Start()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("LastCompletedLevel", 0);

        // Активируем только доступные уровни
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i <= lastCompletedLevel)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        // Сохраняем выбранный уровень в PlayerPrefs
        PlayerPrefs.SetInt("SelectedLevel", levelIndex);
        PlayerPrefs.Save();


        // Загружаем сцену Game
        SceneManager.LoadScene("GameScene");
    }
}
