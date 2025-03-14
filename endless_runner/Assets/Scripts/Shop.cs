using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI shopCoins;

    private float coins;
    private int currentSkin;

    private int manequin;
    private int timmy;
    private int mousey;
    private int ninja;

    void Start()
    {
        LoadData();
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();
    }

    private void LoadData()
    {
        coins = PlayerPrefs.GetFloat("Coins", 0);
        manequin = PlayerPrefs.GetInt("Manequin", 1); // Prvn� skin je zdarma
        timmy = PlayerPrefs.GetInt("Timmy", 0);
        mousey = PlayerPrefs.GetInt("Mousey", 0);
        ninja = PlayerPrefs.GetInt("Ninja", 0);
        currentSkin = PlayerPrefs.GetInt("CSkin", 1); // V�choz� skin
    }

    private void UpdateCoinText()
    {
        shopCoins.text = "Coins: " + coins.ToString();
    }

    public void BuySkin(int skinIndex, int price, string skinName)
    {
        if (PlayerPrefs.GetInt(skinName, 0) == 1) // Skin je ji� zakoupen
        {
            SetSkin(skinIndex);
            return;
        }

        if (coins >= price) // Hr�� m� dostatek minc�
        {
            coins -= price;
            PlayerPrefs.SetFloat("Coins", coins);
            PlayerPrefs.SetInt(skinName, 1);
            SetSkin(skinIndex);
        }
        else
        {
            Debug.Log("Nedostatek minc�!");
        }
    }

    private void SetSkin(int skinIndex)
    {
        currentSkin = skinIndex;
        PlayerPrefs.SetInt("CSkin", skinIndex);
        PlayerPrefs.Save();
    }

    public void SelectManequin() => BuySkin(1, 0, "Manequin"); // Zdarma
    public void SelectTimmy() => BuySkin(2, 20, "Timmy");
    public void SelectMousey() => BuySkin(3, 30, "Mousey");
    public void SelectNinja() => BuySkin(4, 50, "Ninja");
}