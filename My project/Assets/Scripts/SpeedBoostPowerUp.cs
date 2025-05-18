using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostedSpeed = 10f;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager.instance.ActivatePowerUp(PowerUpType.SpeedBoost, 5f, 10f);
            //Removing Coroutines so that I can streamline the code
            //StartCoroutine(ActivateSpeedBoost(other));
            gameObject.SetActive(false);
        }
    }
    private IEnumerator ActivateSpeedBoost(Collider player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.SetSpeed(boostedSpeed);
            yield return new WaitForSeconds(duration);
            movement.ResetSpeed();

        }
    }
}
