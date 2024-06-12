using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    private Spawner ac;
    public GameObject asteroid;

    private void Start()
    {
        GameObject spawner = GameObject.Find("Spawner");
        if (spawner != null)
        {
            ac = spawner.GetComponent<Spawner>();
           
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Finesh"))
        {
            Finesh();
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            Player();
        }

    }

    private void Finesh()
    {
        Destroy(asteroid);

        if (ac != null)
        {
            ac.asteroidNow--;
        }
    }

    private void Player()
    {
        Destroy(asteroid);

        if (ac != null)
        {
            ac.asteroidNow--;
        }
    }


}
