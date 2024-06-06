using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float speed;
    public int hp;

    private float derX, derY;
    public Joystick joystick;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(derX, derY);
    }

    private void Movement()
    {
        derX = joystick.Horizontal * speed;
        derY = joystick.Vertical * speed;
    }

    //Damage не работает хуй знает почему
    private void OnCollisionEnter2D(Collision2D collision)//OnTriggerEnter2D
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            hp--;

            Debug.Log(hp);
        }
    }

}
