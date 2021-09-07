using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject groundTile;
    
    private Vector3 nextSpawnPoint;


    public void SpawnTile(bool spawnItems)
    { 
       // nextSpawnPoint.y = 0.5f;
       GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;

       if (spawnItems)
       {
           temp.GetComponent<GroundTile>().SpawnCoins();
           temp.GetComponent<GroundTile>().SpawnObstacle();
           temp.GetComponent<GroundTile>().SpawnEnemy();
       }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            SpawnTile(i > 2); //do not spawn items on the first 2 tiles
        }
    }

    
  
}
