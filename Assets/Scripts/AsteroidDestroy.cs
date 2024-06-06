using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    private AsteroidController ac;
    public GameObject asteroid;

    private void Start()
    {
        GameObject spawner = GameObject.Find("Spawner(Asteroids)");
        if (spawner != null)
        {
            ac = spawner.GetComponent<AsteroidController>();
           
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Finesh"))
        {
            Destroy(asteroid); 

            if (ac != null)
            {
                ac.asteroidNow--; 
            }
        }
        
    }
}
