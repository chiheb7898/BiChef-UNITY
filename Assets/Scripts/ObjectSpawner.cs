using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Vegetables;
    public GameObject MetalObstacle;
    public Transform SpawnPoint;
    public float IntervalBetweenSpawn; //1s

    private float spawnBetweenTime;
    private int vegitableSpawnCounterForObstacle;

    private void Start()
    {
        Vegetables = IngredCarrier.ingred;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnBetweenTime <= 0)
        {
            int vegetableRandomIndex = Random.Range(0, Vegetables.Length);
            int obstacleSpawnLimit = Random.Range(1, 3);

            if(obstacleSpawnLimit == 2)
            {
                if(vegitableSpawnCounterForObstacle > 6)
                {
                    Instantiate(MetalObstacle, SpawnPoint.position, Quaternion.identity);
                    vegitableSpawnCounterForObstacle = 0;
                }
                else
                {
                    SpawnVegetable(vegetableRandomIndex);
                }
            }
            else
            {
                SpawnVegetable(vegetableRandomIndex);
            }
            
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else
        {
            spawnBetweenTime -= Time.deltaTime;
        }
        
    }

    private void SpawnVegetable(int index)
    {
        Instantiate(Vegetables[index], SpawnPoint.position, Quaternion.identity);
        vegitableSpawnCounterForObstacle++;
    }
}
