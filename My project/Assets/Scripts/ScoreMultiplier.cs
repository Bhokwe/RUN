using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ScoreMultiplier triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected! Activating ScoreMultiplier...");
            PowerUpManager.instance.ActivatePowerUp(PowerUpType.ScoreMultiplier, duration, 2f);
            gameObject.SetActive(false);
        }
    }
}