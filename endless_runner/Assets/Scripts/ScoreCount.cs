using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class ScoreCount : MonoBehaviour
{
    public float distance;
    public Transform player;
    public TextMeshProUGUI score;

    void Start()
    {
        transform.position = player.position;
        distance = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        distance = MathF.Round(distance); /*https://discussions.unity.com/t/how-to-round-a-float/574796*/
        score.text = distance.ToString();
    }
}