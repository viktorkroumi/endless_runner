using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class ScoreCount : MonoBehaviour
{
    public float distance;
    public Transform player;
    public TextMeshProUGUI scoreInGame;
    public static float score;

    void Start()
    {
        transform.position = player.position;
        distance = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        score = MathF.Round(distance); /*https://discussions.unity.com/t/how-to-round-a-float/574796*/
        scoreInGame.text = score.ToString();
    }
}