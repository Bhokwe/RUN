using System.Collections;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager.instance.ActivatePowerUp(PowerUpType.ScoreMulitplier, 10f, 2f);
            //StartCoroutine(ActivatePowerUp());
            gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivatePowerUp()
    {
        ScoreManager.instance.SetMultiplier(2);
        yield return new WaitForSeconds(duration);

    }
}
