using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    private static bool firstLoad = true;

    private static int highScore = 0;

    private const string HIGHSCORE_KEY = "highScore";

    [SerializeField] private Text lastScoreText = null;
    [SerializeField] private Text highScoreText = null;

    private void Start()
    {
        if (firstLoad)
        {
            if (PlayerPrefs.HasKey(HIGHSCORE_KEY))
            {
                highScore = PlayerPrefs.GetInt(HIGHSCORE_KEY);
            }

            firstLoad = false;
        }

        if (GameManager.score > highScore)
        {
            highScore = GameManager.score;
            PlayerPrefs.SetInt(HIGHSCORE_KEY, highScore);
        }

        lastScoreText.text = GameManager.score.ToString();
        highScoreText.text = highScore.ToString();
    }
}
