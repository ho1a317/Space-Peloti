using UnityEngine;

public class Heartsystem : MonoBehaviour
{
    public static int Health { get; private set; }

    public GameObject Heart1, Heart2, Heart3, Heart4, Heart5;

    void Start()
    {
        LifeStart();
    }

    void Update()
    {
        LifeCount(Health);
    }

    public void LifeStart()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        Heart4.SetActive(true);
        Heart5.SetActive(true);
    }

    private void LifeCount(int health)
    {
        switch (health)
        {
            case 5:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                break;
            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(false);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
        }
    }

    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }
    }

    
    public void SetHealth(int health)
    {
        Health = health;
    }
}
