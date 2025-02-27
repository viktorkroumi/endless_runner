using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    //https://discussions.unity.com/t/how-to-detect-collision-on-only-one-side-of-an-object-c/214851
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "DeathCollider")
        {
            SceneManager.LoadScene(0);
        }
    }
}
