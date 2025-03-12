using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionDetection : MonoBehaviour
{
    public static float coinCount;
    public TextMeshProUGUI coinText;
    public GameObject coin;

    void Start()
    {
        coinCount = PlayerPrefs.GetFloat("Coins");
        coinText.text = PlayerPrefs.GetFloat("Coins").ToString();
    }
  
    private void OnTriggerEnter(Collider coin)
    {
        coinCount++;

        if (PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetFloat("Coins", coinCount);
        }
        else
        {
            PlayerPrefs.SetFloat("Coins", coinCount);
        }

        coinText.text = PlayerPrefs.GetFloat("Coins").ToString();
        Destroy(coin.gameObject);
    }


    //https://discussions.unity.com/t/how-to-detect-collision-on-only-one-side-of-an-object-c/214851

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DeathCollider")
        {
            SceneManager.LoadScene(0);
        }
    }
}
