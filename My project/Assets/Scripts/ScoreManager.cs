using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{


    public static ScoreManager instance;

    private int score = 0;
    private int multiplier = 1;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {

            Destroy(gameObject);
        }

    }

    public void AddScore()
    {
        score += score * multiplier;
    }

    public void SetMultiplier(int newMultiplier) {  multiplier = newMultiplier; }


    public void ResetMultiplier() { multiplier = 1; }
}
