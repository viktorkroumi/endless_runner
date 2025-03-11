using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    public static float coinCount;
    public TextMeshProUGUI coinText;
    public GameObject coin;

    void Start()
    {
        coinText.text = coinCount.ToString();
    }

    //https://discussions.unity.com/t/how-to-detect-collision-on-only-one-side-of-an-object-c/214851

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "DeathCollider")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider coin)
    {
        coinCount++;            
        coinText.text = coinCount.ToString();
        Destroy(coin.gameObject);
    }
}
