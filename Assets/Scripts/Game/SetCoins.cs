using UnityEngine;
using UnityEngine.UI;

public class SetCoins : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
    }
}
