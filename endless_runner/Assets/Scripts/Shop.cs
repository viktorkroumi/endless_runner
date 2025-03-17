using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI shopCoins;
    public TextMeshProUGUI manequintxt;
    public TextMeshProUGUI timmytxt;
    public TextMeshProUGUI mouseytxt;
    public TextMeshProUGUI ninjatxt;

    private float coins;
    private int currentSkin;
    private int manequin;
    private int timmy;
    private int mousey;
    private int ninja;

    void Start()
    {
        manequintxt.text = "0";
        timmytxt.text = "800";
        mouseytxt.text = "1200";
        ninjatxt.text = "2000";

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
        manequin = PlayerPrefs.GetInt("Manequin", 1); // První skin je zdarma
        timmy = PlayerPrefs.GetInt("Timmy", 0);
        mousey = PlayerPrefs.GetInt("Mousey", 0);
        ninja = PlayerPrefs.GetInt("Ninja", 0);
        currentSkin = PlayerPrefs.GetInt("CSkin", 1); // Výchozí skin
    }

    private void UpdateCoinText()
    {
        shopCoins.text = coins.ToString();
    }

    public void BuySkin(int skinIndex, int price, string skinName)
    {
        if (PlayerPrefs.GetInt(skinName, 0) == 1) // Skin je již zakoupen
        {
            SetSkin(skinIndex);
            return;
        }

        if (coins >= price) // Hráè má dostatek mincí
        {
            coins -= price;
            PlayerPrefs.SetFloat("Coins", coins);
            PlayerPrefs.SetInt(skinName, 1);
            SetSkin(skinIndex);
        }
        else
        {
            Debug.Log("Nedostatek mincí!");
        }
    }

    private void SetSkin(int skinIndex)
    {
        currentSkin = skinIndex;
        PlayerPrefs.SetInt("CSkin", skinIndex);
        PlayerPrefs.Save();
    }

    public void SelectManequin() => BuySkin(1, 0, "Manequin"); // Zdarma
    public void SelectTimmy() => BuySkin(2, 800, "Timmy");
    public void SelectMousey() => BuySkin(3, 1200, "Mousey");
    public void SelectNinja() => BuySkin(4, 2000, "Ninja");
}