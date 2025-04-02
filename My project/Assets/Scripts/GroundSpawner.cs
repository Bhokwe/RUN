using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject ground;
    Vector3 nextSpawnPoint;


    public void SpawnTile()
    {
        //Debug.Log("Spawning a new tile");
        GameObject temp = Instantiate(ground, nextSpawnPoint, Quaternion.identity); 

        nextSpawnPoint= temp.transform.GetChild(1).transform.position;
        Debug.Log("Updated nextSpawnPoint" + nextSpawnPoint);
    }
    private void Start()
    {
        for (int i = 0; i < 15; i++) 
        {
            SpawnTile();
        }

        
       
    }


}
