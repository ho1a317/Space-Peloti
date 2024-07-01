using UnityEngine;
using UnityEngine.Purchasing;

public class Purchase : MonoBehaviour
{
    public void OnPurchaseSuccessful(Product product)
    {
        switch (product.definition.id)
        {
            case "coins100":
                Add100Coins();
                break;
        }
    }

    private void Add100Coins()
    {
        int coins = PlayerPrefs.GetInt("Money");
        coins += 100;
        PlayerPrefs.SetInt("Money", coins);

        UIInfo.Instance.UpdateCoinsText();
    }


}
