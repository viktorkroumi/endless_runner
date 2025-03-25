using TMPro;
using UnityEngine;

public class MenuScore : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
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
        currentScore.text = "Your score: " + score.ToString();
    }
}
