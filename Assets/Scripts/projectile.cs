using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    private Vector3 target;
    public PlayerController playerController;
    private int speed = 5;
    private Vector3 current;
    private double lifespan=10;
    private Vector3 direction;
    GameManager Gm;

    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();
        playerController = FindFirstObjectByType<PlayerController>();
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        direction = ((target - transform.position).normalized)*speed;
    }

    private void Update()
    {
        lifespan -= Time.deltaTime;
        transform.position +=  (direction * Time.deltaTime);
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Gm.health -= 1;
            print(Gm.health);
        }
    }

    private void OnCollisionEnter2D(Collision other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Destroy(other.gameObject);
        }
    }
}