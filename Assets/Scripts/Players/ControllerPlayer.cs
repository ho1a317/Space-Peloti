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


}
