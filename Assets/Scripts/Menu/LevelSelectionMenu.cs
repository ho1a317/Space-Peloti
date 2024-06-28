using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("LastCompletedLevel", 0);

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
        PlayerPrefs.SetInt("SelectedLevel", levelIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene("GameScene");
    }
}
