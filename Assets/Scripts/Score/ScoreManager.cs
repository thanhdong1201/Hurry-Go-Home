using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{  
    [SerializeField] private ScoreSO scoreSO;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private bool gameOver = true;
    private float timer = 0;

    private void Awake()
    {

    }
    private void Start()
    {
        scoreSO.ResetScore();
    }
    private void Update()
    {
        if (gameOver)
        {
            finalScoreText.SetText("Your Score: " + scoreSO.CurrentScore);
        }
       
        if (!gameOver)
        {
            scoreText.SetText("Score: " + scoreSO.CurrentScore);
            timer += Time.deltaTime;
            if(timer >= 2)
            {
                scoreSO.AddScore(10);
                timer = 0;
            }
        }
    }
    public void ContinueAddScore()
    {
        gameOver = false;
    }
    public void StopAddScore()
    {
        gameOver = true;
    }
}
