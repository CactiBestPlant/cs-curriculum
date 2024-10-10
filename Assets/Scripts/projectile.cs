using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public int speed; // Speed of the projectile
    private Vector3 target;
    private PlayerController PlayerController;
    private Vector3 current;
    private Vector3 direction;


    private void Start()
    {
        speed = 5;
        target = new Vector3(PlayerController.playerX, PlayerController.playerY, 0);
        direction = (target - transform.position).normalized;
    }

    private void Update()
    {
        Vector3 current = transform.position;
        Vector3 newposition = Vector3.MoveTowards(current, target, speed + Time.deltaTime);
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}