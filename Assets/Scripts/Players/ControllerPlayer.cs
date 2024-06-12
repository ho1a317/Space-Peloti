using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public float speed;
    public int hp;

    private float derX, derY;
    public Joystick joystick;

    public Text Coin;

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

    //Damage смерть и ефекты 
    //OnTriggerEnter2D(MB na Coin)   OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Damage();
        }

        if (collision.gameObject.tag == "Coin")
        {
            CollectorCoins();
        }
    }
    // DEL
    private void Damage()
    {
        hp--;

        Debug.Log(hp);
    }

    private void CollectorCoins()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1);
        Coin.text = Convert.ToString(Convert.ToInt32(Coin.text) + 1);

    }

}
