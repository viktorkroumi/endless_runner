using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    //https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.Rotate.html

    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
    }
}
