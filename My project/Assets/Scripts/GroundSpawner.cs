using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public Transform player; // Assign in Inspector
    public float tileLength = 10f;
    public int initialTiles = 15;
    public float despawnDistance = 30f;

    private Vector3 nextSpawnPoint;
    private List<GameObject> activeTiles = new List<GameObject>();
    private Queue<GameObject> tilePool = new Queue<GameObject>();
    private int hardTileStreak = 0;
    private int maxHardTileStreak = 2;

    private void Start()
    {
        for (int i = 0; i < initialTiles; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        if (player == null || activeTiles.Count == 0) return;

        GameObject firstTile = activeTiles[0];
        if (firstTile == null)
        {
            activeTiles.RemoveAt(0);
            return;
        }

        float distanceFromPlayer = player.position.z - firstTile.transform.position.z;

        if (distanceFromPlayer > despawnDistance)
        {
            RecycleTile(firstTile);
            activeTiles.RemoveAt(0);
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject prefabToUse;
        if (hardTileStreak >= maxHardTileStreak)
        {
            prefabToUse = groundPrefabs[0]; // Force an easy tile
            hardTileStreak = 0;
        }
        else
        {
            prefabToUse = groundPrefabs[UnityEngine.Random.Range(0, groundPrefabs.Length)];
            if (Array.IndexOf(groundPrefabs, prefabToUse) > 0)
                hardTileStreak++;
            else
                hardTileStreak = 0;
        }

        GameObject tile = GetTileFromPool(prefabToUse);

        tile.transform.position = nextSpawnPoint;
        tile.transform.rotation = Quaternion.identity;

        tile.SetActive(true);

        if (tile.transform.childCount > 1)
        {
            nextSpawnPoint = tile.transform.GetChild(1).position;
        }
        else
        {
            Debug.LogWarning("Tile prefab does not have enough children for spawn point. Using default offset.");
            nextSpawnPoint += new Vector3(0, 0, tileLength);
        }

        activeTiles.Add(tile);
    }

    private GameObject GetTileFromPool(GameObject prefab)
    {
        if (tilePool.Count > 0)
        {
            GameObject pooledTile = tilePool.Dequeue();
            if (pooledTile != null && pooledTile.name.StartsWith(prefab.name))
                return pooledTile;
        }

        return Instantiate(prefab);
    }

    private void RecycleTile(GameObject tile)
    {
        tile.SetActive(false);
        tilePool.Enqueue(tile);
    }
}