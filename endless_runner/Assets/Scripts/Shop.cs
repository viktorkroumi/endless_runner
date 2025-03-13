using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Toto pole obsahuje indexy pro rùzné skiny
    public int[] skinPrices;  // Ceny skinù
    public TextMeshProUGUI coinText; // Zobrazení poètu mincí hráèe

    void Start()
    {
        // Inicializace UI pro poèet mincí
        UpdateCoinText();
    }

    private void Update()
    {
        UpdateCoinText();
    }

    // Funkce pro nákup skinu
    public void BuySkin(int skinIndex)
    {
        // Získáme aktuální poèet mincí hráèe
        float currentCoins = PlayerPrefs.GetFloat("Coins");

        // Cena skinu
        float skinPrice = skinPrices[skinIndex];

        // Pokud má hráè dostatek mincí
        if (currentCoins >= skinPrice)
        {
            // Odeèteme cenu skinu
            currentCoins -= skinPrice;
            PlayerPrefs.SetFloat("Coins", currentCoins);

            // Oznaèíme skin jako zakoupený v PlayerPrefs
            PlayerPrefs.SetInt("Skin" + skinIndex, 1);

            // Aktivujeme vybraný skin pomocí Singletonu
            SkinManager.Instance.ActivateSkin(skinIndex);

            // Aktualizujeme UI pro poèet mincí
            UpdateCoinText();
        }
    }

    // Metoda pro aktualizaci textu s poètem mincí
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + PlayerPrefs.GetFloat("Coins").ToString();
    }
}