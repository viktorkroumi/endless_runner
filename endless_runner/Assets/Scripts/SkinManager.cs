using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins; // Pole všech skinù

    void Start()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        int selectedSkin = PlayerPrefs.GetInt("CSkin", 1); // Získání aktuálního skinu (výchozí = 1)

        // Vypnutí všech skinù
        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        // Aktivace vybraného skinu
        if (selectedSkin > 0 && selectedSkin <= skins.Length)
        {
            skins[selectedSkin - 1].SetActive(true);
        }
    }
}
