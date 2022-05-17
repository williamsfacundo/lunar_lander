using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;

    private int score;
    
    private void Start()
    {
        score = 0;
    }
   
    private void Update()
    {
        scoreText.text = "Score " + score;
    }

    public void ScoreUp(int _score) 
    {
        score += _score;
    }
}
