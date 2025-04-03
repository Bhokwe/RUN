using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //if (groundSpawner == null )
        //{
        //    //Debug.LogError("Its not found in the scene");
        //}
        SpawnObstacle();
        CoinSpawner();
    }

    void OnTriggerExit(Collider other)
    {
        //if ( groundSpawner == null)
        //{
        //    //Debug.LogError("Groundspawner is null on Trigger what what!");
        //    return;
        //}

        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        //Get a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject coinPrefab;

    void CoinSpawner()
    {
        int coinsSpawned = 8;
        for (int i = 0; i < coinsSpawned; i++) 
         {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        
        
        
        }


    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
            Vector3 point = new Vector3
                (
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );
            if(point != collider.ClosestPoint(point))
            {
              point = GetRandomPointInCollider (collider);

            }

        point.y = 1;
        return point;

            


            


    }
}
