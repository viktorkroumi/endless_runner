using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    public TextMeshProUGUI latestScore;

    void Update()
    {
        latestScore.text = "Score: " + ScoreCount.score.ToString();
    }
}
