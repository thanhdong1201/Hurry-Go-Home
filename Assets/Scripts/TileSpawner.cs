using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public List<GameObject> activeTiles = new List<GameObject>();
    public float tileLength = 100;
    public float numberOfTiles = 3;

    private float nextSpawnPosition = 0;
    private Transform playerTransform;

    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Start()
    {    
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    private void Update()
    {
        if(playerTransform.position.z -70 > nextSpawnPosition - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DestroyTile(0);
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject tilePrefab = Instantiate(tilePrefabs[tileIndex], transform.right * nextSpawnPosition, transform.rotation);
        activeTiles.Add(tilePrefab);
        nextSpawnPosition += tileLength;
    }
    private void DestroyTile(int tileIndex)
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
