using UnityEngine;

public class SkinManager : MonoBehaviour
{
    // Statická instance pro Singleton (to je ta jediná instance, která bude existovat)
    public static SkinManager Instance;

    // Pole pro modely skinù (GameObjecty, které reprezentují rùzné skiny)
    public GameObject[] skins;

    // Funkce, která se zavolá pøi inicializaci objektu (Awake je voláno ještì pøed Start)
    private void Awake()
    {
        // Pokud už instance existuje, znièíme tuto instanci
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Pokud instance neexistuje, pøiøadíme tuto instanci a zachováme ji mezi scénami
            Instance = this;
            DontDestroyOnLoad(gameObject); // Tento objekt bude pøežít mezi scénami
        }
    }

    // Metoda pro aktivaci skinu podle indexu
    public void ActivateSkin(int skinIndex)
    {
        // Deaktivujeme všechny skiny
        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        // Aktivujeme konkrétní skin
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            skins[skinIndex].SetActive(true);
        }
    }
}
