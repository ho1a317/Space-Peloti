using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    private Spawner spaw;
    public GameObject asteroid;

    private void Start()
    {
        GameObject spawner = GameObject.Find("Spawner");
        if (spawner != null)
        {
            spaw = spawner.GetComponent<Spawner>();
           
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

        if (spaw != null)
        {
            spaw.asteroidNow--;
        }
    }

    private void Player()
    {
        Destroy(asteroid);

        if (spaw != null)
        {
            spaw.asteroidNow--;
        }
    }


}
