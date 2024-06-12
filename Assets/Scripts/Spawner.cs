using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int asteroidCount;
    public float spawnInterval = 2.0f;
    public float posY;
    
    [HideInInspector]
    public int asteroidNow;

    [SerializeField]
    private GameObject[] asteroidPrefabs;
    private GameObject asteroid;

    private void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            if (asteroidNow < asteroidCount)
            {
                int randAsteroid = Random.Range(0, asteroidPrefabs.Length);
                asteroid = Instantiate(asteroidPrefabs[randAsteroid]) as GameObject;
                asteroid.transform.position = new Vector2(Random.Range(-2f, 2f), posY);

                asteroidNow++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}