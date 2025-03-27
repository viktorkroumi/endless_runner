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
        LoadData();
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();
    }

    //https://www.youtube.com/watch?v=sKZqqWGqdcc&t=37s

    private void LoadData()
    {
        coins = PlayerPrefs.GetFloat("Coins", 0);
        manequin = PlayerPrefs.GetInt("Manequin", 1);
        timmy = PlayerPrefs.GetInt("Timmy", 0);
        mousey = PlayerPrefs.GetInt("Mousey", 0);
        ninja = PlayerPrefs.GetInt("Ninja", 0);
        currentSkin = PlayerPrefs.GetInt("CSkin", 1);
        UpdateSkinText();
    }

    private void UpdateCoinText()
    {
        shopCoins.text = coins.ToString();
    }

    private void UpdateSkinText()
    {
        manequintxt.text = GetSkinStatus("Manequin", 1, 0);
        timmytxt.text = GetSkinStatus("Timmy", 2, 3000);
        mouseytxt.text = GetSkinStatus("Mousey", 3, 5000);
        ninjatxt.text = GetSkinStatus("Ninja", 4, 10000);
    }

    //ChatGPT

    private string GetSkinStatus(string skinName, int skinIndex, int price)
    {
        if (currentSkin == skinIndex)
        {
            return "Equipped";
        }

        return PlayerPrefs.GetInt(skinName, 0) == 1 ? "Owned" : price.ToString();
    }

    public void BuySkin(int skinIndex, int price, string skinName)
    {
        if (PlayerPrefs.GetInt(skinName, 0) == 1)
        {
            SetSkin(skinIndex);
            return;
        }

        if (coins >= price)
        {
            coins -= price;
            PlayerPrefs.SetFloat("Coins", coins);
            PlayerPrefs.SetInt(skinName, 1);
            SetSkin(skinIndex);
        }
    }

    private void SetSkin(int skinIndex)
    {
        currentSkin = skinIndex;
        PlayerPrefs.SetInt("CSkin", skinIndex);
        PlayerPrefs.Save();
        UpdateSkinText();
    }

    public void SelectManequin() => BuySkin(1, 0, "Manequin");
    public void SelectTimmy() => BuySkin(2, 3000, "Timmy");
    public void SelectMousey() => BuySkin(3, 5000, "Mousey");
    public void SelectNinja() => BuySkin(4, 10000, "Ninja");
}