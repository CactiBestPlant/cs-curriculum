using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;
    public static GameManager Gm;
    
    public int coins;
    public int health;

    private void Awake()
    {
        health = 100;
        if (Gm != null && Gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        coinsText.text = ("Coins:") + coins;
        healthText.text = ("Health:") + health;
    }

    private void Update()
    {
        coinsText.text = ("Coin:") + coins;
        if (health > 0)
        {
            healthText.text = ("Health:") + health;
        }
        else
        {
            healthText.text = ("RESTART SWINE");
        }
    }
}



    
