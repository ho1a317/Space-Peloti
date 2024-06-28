using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int healthUpgradeCost = 100;
    public int coinValueUpgradeCost = 150;
    public int speedUpgradeCost = 200;

    public GameObject[] healthUpgradeIcons;
    public GameObject[] coinValueUpgradeIcons;
    public GameObject[] speedUpgradeIcons;
    public Text playerCoinsText;

    private int healthLevel;
    private int coinValueLevel;
    private int speedLevel;

    void Start()
    {
        LoadUpgrades();
        UpdateUI();
    }

    public void BuyHealthUpgrade()
    {
        int playerCoins = PlayerPrefs.GetInt("Money", 0);
        if (playerCoins >= healthUpgradeCost && healthLevel < 3)
        {
            playerCoins -= healthUpgradeCost;
            healthLevel++;
            PlayerPrefs.SetInt("Money", playerCoins);
            PlayerPrefs.SetInt("HealthLevel", healthLevel);
            PlayerPrefs.Save();
            UpdateUI();
        }
        else
        {
            Debug.Log("Limit reached for health upgrades");
            // Анимация или уведомление о лимите
        }
    }

    public void BuyCoinValueUpgrade()
    {
        int playerCoins = PlayerPrefs.GetInt("Money", 0);
        if (playerCoins >= coinValueUpgradeCost && coinValueLevel < 3)
        {
            playerCoins -= coinValueUpgradeCost;
            coinValueLevel++;
            PlayerPrefs.SetInt("Money", playerCoins);
            PlayerPrefs.SetInt("CoinValueLevel", coinValueLevel);
            PlayerPrefs.Save();
            UpdateUI();
        }
        else
        {
            Debug.Log("Limit reached for coin value upgrades");
            // Анимация или уведомление о лимите
        }
    }

    public void BuySpeedUpgrade()
    {
        int playerCoins = PlayerPrefs.GetInt("Money", 0);
        if (playerCoins >= speedUpgradeCost && speedLevel < 3)
        {
            playerCoins -= speedUpgradeCost;
            speedLevel++;
            PlayerPrefs.SetInt("Money", playerCoins);
            PlayerPrefs.SetInt("SpeedLevel", speedLevel);
            PlayerPrefs.Save();
            UpdateUI();
        }
        else
        {
            Debug.Log("Limit reached for speed upgrades");
            // Анимация или уведомление о лимите
        }
    }

    private void LoadUpgrades()
    {
        healthLevel = PlayerPrefs.GetInt("HealthLevel", 0);
        coinValueLevel = PlayerPrefs.GetInt("CoinValueLevel", 0);
        speedLevel = PlayerPrefs.GetInt("SpeedLevel", 0);
    }

    private void UpdateUI()
    {
        UpdateUpgradeIcons(healthUpgradeIcons, healthLevel);
        UpdateUpgradeIcons(coinValueUpgradeIcons, coinValueLevel);
        UpdateUpgradeIcons(speedUpgradeIcons, speedLevel);
        playerCoinsText.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }

    private void UpdateUpgradeIcons(GameObject[] icons, int level)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < level)
            {
                icons[i].SetActive(true);
            }
            else
            {
                icons[i].SetActive(false);
            }
        }
    }
}
