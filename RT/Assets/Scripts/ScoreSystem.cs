using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [Header("Main")]
    [Space]
    public int scoreAmount = 0;

    [Space]

    [Header("Components")]
    [Space]
    [SerializeField] private Text scoreText = null;

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "����: " + scoreAmount.ToString();
    }
}
