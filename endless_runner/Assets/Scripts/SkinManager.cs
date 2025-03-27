using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins;

    void Start()
    {
        SetSkin();
    }

    //ChatGPT

    public void SetSkin()
    {
        int selectedSkin = PlayerPrefs.GetInt("CSkin", 1);

        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        if (selectedSkin > 0 && selectedSkin <= skins.Length)
        {
            skins[selectedSkin - 1].SetActive(true);
        }
    }
}
