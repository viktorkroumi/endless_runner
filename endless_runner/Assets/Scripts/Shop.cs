using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Toto pole obsahuje indexy pro r�zn� skiny
    public int[] skinPrices;  // Ceny skin�
    public TextMeshProUGUI coinText; // Zobrazen� po�tu minc� hr��e

    void Start()
    {
        // Inicializace UI pro po�et minc�
        UpdateCoinText();
    }

    private void Update()
    {
        UpdateCoinText();
    }

    // Funkce pro n�kup skinu
    public void BuySkin(int skinIndex)
    {
        // Z�sk�me aktu�ln� po�et minc� hr��e
        float currentCoins = PlayerPrefs.GetFloat("Coins");

        // Cena skinu
        float skinPrice = skinPrices[skinIndex];

        // Pokud m� hr�� dostatek minc�
        if (currentCoins >= skinPrice)
        {
            // Ode�teme cenu skinu
            currentCoins -= skinPrice;
            PlayerPrefs.SetFloat("Coins", currentCoins);

            // Ozna��me skin jako zakoupen� v PlayerPrefs
            PlayerPrefs.SetInt("Skin" + skinIndex, 1);

            // Aktivujeme vybran� skin pomoc� Singletonu
            SkinManager.Instance.ActivateSkin(skinIndex);

            // Aktualizujeme UI pro po�et minc�
            UpdateCoinText();
        }
    }

    // Metoda pro aktualizaci textu s po�tem minc�
    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + PlayerPrefs.GetFloat("Coins").ToString();
    }
}