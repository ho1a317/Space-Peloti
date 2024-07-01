using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    public static UIInfo Instance;

    [SerializeField] Text textCoins;

    private void Start()
    {
        Instance = this;
        UpdateCoinsText();
    }

    public void UpdateCoinsText()
    {
        int coin = PlayerPrefs.GetInt("Money");
        textCoins.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }
}
