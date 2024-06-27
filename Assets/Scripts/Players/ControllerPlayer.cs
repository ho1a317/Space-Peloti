using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{

    public float speed;
    public int maxHp; // Базовое максимальное значение здоровья

    public int nowHp;
    public int damage = 1;

    public int coinValue = 1; // Базовая стоимость монеты


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

        // Применение улучшений
        ApplyUpgrades();

        // Устанавливаем начальное значение здоровья
        // nowHp = maxHp;
        heartSystem.SetHealth(maxHp);
    }

    private void ApplyUpgrades()
    {
        int healthUpgrades = PlayerPrefs.GetInt("HealthLevel", 0);
        int coinValueUpgrades = PlayerPrefs.GetInt("CoinValueLevel", 0);
        int speedUpgrades = PlayerPrefs.GetInt("SpeedLevel", 0);

        maxHp += healthUpgrades;
        coinValue += coinValueUpgrades;
        speed += speedUpgrades;
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

    // Обработка столкновений
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

    // Метод для восстановления здоровья при перезапуске уровня
    public void ResetHealth()
    {
        nowHp = maxHp;
        heartSystem.SetHealth(maxHp);
    }
}
