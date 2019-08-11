using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;

    private void LateUpdate()
    {
        scoreText.text = GameManager.score.ToString();
    }
}
