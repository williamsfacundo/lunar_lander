using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;    

    private static int score = 0;    

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay") 
        {
            score = 0;
        }        
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
