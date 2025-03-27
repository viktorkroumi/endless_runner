using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;

public class ScoreCount : MonoBehaviour
{
    public float distance;
    public static float score;
    public Transform player;
    public TextMeshProUGUI currentScore;

    void Start()
    {
        transform.position = player.position;
        distance = 0;
        currentScore.text = score.ToString();
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        score = MathF.Round(distance);                                      /*https://discussions.unity.com/t/how-to-round-a-float/574796 */
        currentScore.text = score.ToString();
    }
}