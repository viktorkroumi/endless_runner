using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    public TextMeshProUGUI latestScore;
    public TextMeshProUGUI highScore;
    public float score;

    void Update()
    {
        score = ScoreCount.score;

        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetFloat("SavedHighScore"))
            {
                PlayerPrefs.SetFloat("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("SavedHighScore", score);
        }

        highScore.text = "Highest score: " + PlayerPrefs.GetFloat("SavedHighScore").ToString();
        latestScore.text = "Your score: " + score.ToString();
    }
}
