using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    private Coroutine scoreMultiplierCoroutine;
    private Coroutine speedBoostCoroutine;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


    }
    public void ActivatePowerUp(PowerUpType type, float duration, float value)
    {
        switch (type)
        {
            case PowerUpType.ScoreMultiplier:
                if (scoreMultiplierCoroutine != null)
                    StopCoroutine(scoreMultiplierCoroutine);
                scoreMultiplierCoroutine = StartCoroutine(ScoreMultiplierRoutine(duration, (int)value));
                break;

            case PowerUpType.SpeedBoost:
                if (speedBoostCoroutine != null)
                    StopCoroutine(speedBoostCoroutine);
                speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine(duration, value));
                break;
        }
    }

    private IEnumerator ScoreMultiplierRoutine(float duration, int multiplier)
    {
        ScoreManager.instance.SetMultiplier(multiplier);
        yield return new WaitForSeconds(duration);
        ScoreManager.instance.ResetMultiplier();
    }

    private IEnumerator SpeedBoostRoutine(float duration, float speed)
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            player.SetSpeed(speed);
            yield return new WaitForSeconds(duration);
            player.ResetSpeed();
        }
    }
}
