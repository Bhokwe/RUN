using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    public Text scoreText;

    public void IncrementScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score;

        }
        else {
            Debug.LogError("ScoreText is not assigned");
        
        }

        
    }
    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
