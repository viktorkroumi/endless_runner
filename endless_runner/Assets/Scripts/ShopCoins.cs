using TMPro;
using UnityEngine;

public class ShopCoins : MonoBehaviour
{
    public TextMeshProUGUI shopCoins;

    void Update()
    {
        shopCoins.text = "Coins: " + PlayerPrefs.GetFloat("Coins").ToString();
    }
}
