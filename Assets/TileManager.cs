using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float xSpawn;
    public float tileLength;
    private List<GameObject> activeTiles = new List<GameObject>();
    public int numberOfTiles;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, tilePrefabs.Length)); 
            }
        }
    }

    private void FixedUpdate()
    {
        if (player.position.x - 140 > xSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTiles();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.right * xSpawn, transform.rotation);
        activeTiles.Add(go);
        xSpawn += tileLength;
    }

    private void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
