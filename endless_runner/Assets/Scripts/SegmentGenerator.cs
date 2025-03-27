using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    //https://www.youtube.com/watch?v=rEn57zwzFGw&list=PLZ1b66Z1KFKiR-IVN688Jo0BbOh4aV6Dt&index=9

    public GameObject[] segment;
    private int zPosition = 50;
    private bool creatingSegment = false;
    private int segmentNum;

    void Start()
    {
        segmentNum = Random.Range(0, 8);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += 50;
    }

    void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 8);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);
        zPosition += 50;
        yield return new WaitForSeconds(2);
        creatingSegment = false;
    }
}
