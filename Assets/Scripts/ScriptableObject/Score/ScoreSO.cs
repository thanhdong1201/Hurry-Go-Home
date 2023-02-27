using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Score")]
public class ScoreSO : ScriptableObject
{
    [Header("Only read value. Do not change any value in here")]
    [SerializeField] private int _highestScore;
    [SerializeField] private int _currentScore;


    public int HighestScore => _highestScore;
    public int CurrentScore => _currentScore;


    public void SetHighestScore(int highestScore)
    {
        _highestScore = highestScore;
    }
    public void AddScore(int score)
    {
        _currentScore += score;

        if(_currentScore > _highestScore)
        {
            _highestScore = _currentScore;
        }
    }
    public void ResetScore()
    {
        _currentScore = 0;
    }
}
