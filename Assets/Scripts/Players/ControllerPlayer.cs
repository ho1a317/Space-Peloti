using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public float speed;
    public int initialHealth; // ѕубличное поле дл€ начального значени€ здоровь€

    public int nowHp;

    public int damage = 1;
    public int coinValue = 1;

    private float derX, derY;
    public Joystick joystick;

    public Text Coin;

    private Rigidbody2D rb;
    private Heartsystem heartSystem;
    private GameOverManager gameOverManager;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        heartSystem = FindObjectOfType<Heartsystem>();
        gameOverManager = FindObjectOfType<GameOverManager>();

        // ”станавливаем начальное значение здоровь€
        nowHp = initialHealth;
        heartSystem.SetHealth(initialHealth);
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

    // ќбработка столкновений
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

    private void CollectorCoins()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + coinValue);
        Coin.text = Convert.ToString(Convert.ToInt32(Coin.text) + coinValue);
    }

    private void Damage()
    {
        nowHp--;

        heartSystem.TakeDamage(damage);
        Debug.Log(nowHp);

        if (nowHp <= 0)
        {
            gameOverManager.Lose();
        }
    }

    // ћетод дл€ восстановлени€ здоровь€ при перезапуске уровн€
    public void ResetHealth()
    {
        nowHp = initialHealth;
        heartSystem.SetHealth(initialHealth);
    }
}
