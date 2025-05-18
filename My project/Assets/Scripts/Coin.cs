using NUnit.Framework;
using UnityEngine;

public class Coin : MonoBehaviour
    
{

    public float rotateSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacles>() != null)
        {
            Destroy(gameObject);
        }


        //Does the coin collide with the player
        if(other.gameObject.name != "Player")
        {
            return;
        }

        //Add to the score
        GameManager.inst.IncrementScore();

        //Destroy the coin after it is taken/ out of LOS
        Destroy(gameObject);

        
    }
    
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        
    }
}
