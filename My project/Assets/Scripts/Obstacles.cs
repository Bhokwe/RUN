using UnityEngine;

public class Obstacles : MonoBehaviour
{


    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Death
        if (collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
