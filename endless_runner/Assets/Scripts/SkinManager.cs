using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins; // Pole v�ech skin�

    void Start()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        int selectedSkin = PlayerPrefs.GetInt("CSkin", 1); // Z�sk�n� aktu�ln�ho skinu (v�choz� = 1)

        // Vypnut� v�ech skin�
        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        // Aktivace vybran�ho skinu
        if (selectedSkin > 0 && selectedSkin <= skins.Length)
        {
            skins[selectedSkin - 1].SetActive(true);
        }
    }
}
