using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [Header("Main")]
    [Space]
    public int scoreAmount = 0;

    [Space(20)]

    [Header("Components")]
    [Space]
    [SerializeField] private Text scoreText = null;

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Очки: " + scoreAmount.ToString();
    }
}
