using UnityEngine;

public class SkinManager : MonoBehaviour
{
    // Statick� instance pro Singleton (to je ta jedin� instance, kter� bude existovat)
    public static SkinManager Instance;

    // Pole pro modely skin� (GameObjecty, kter� reprezentuj� r�zn� skiny)
    public GameObject[] skins;

    // Funkce, kter� se zavol� p�i inicializaci objektu (Awake je vol�no je�t� p�ed Start)
    private void Awake()
    {
        // Pokud u� instance existuje, zni��me tuto instanci
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Pokud instance neexistuje, p�i�ad�me tuto instanci a zachov�me ji mezi sc�nami
            Instance = this;
            DontDestroyOnLoad(gameObject); // Tento objekt bude p�e��t mezi sc�nami
        }
    }

    // Metoda pro aktivaci skinu podle indexu
    public void ActivateSkin(int skinIndex)
    {
        // Deaktivujeme v�echny skiny
        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        // Aktivujeme konkr�tn� skin
        if (skinIndex >= 0 && skinIndex < skins.Length)
        {
            skins[skinIndex].SetActive(true);
        }
    }
}
