using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int speed=5; // Speed of the projectile
    private Vector3 target;
    private PlayerController playerController;
    private Vector3 current;
    private double lifespan=35;
    private Vector3 direction;


    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        target = new Vector3(PlayerController.playerX, PlayerController.playerY, 0);
        direction = (target - transform.position).normalized;
    }

    private void Update()
    {
        lifespan -= Time.deltaTime;
        transform.position += speed * direction * Time.deltaTime;
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

   // private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
     //   {
     //       Destroy(gameObject);
     //   }
   // }
}