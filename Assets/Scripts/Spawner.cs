using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int asteroidCount;
    public float spawnInterval = 2.0f;
    public float posY;
    
    public int asteroidNow;

    [SerializeField]
    private GameObject[] asteroidPrefabs;
    private GameObject asteroid;
    
    private void Update()
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

    public void DestroyAllObjects()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }

        allObjects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
    }
}