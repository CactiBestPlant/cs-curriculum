using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Vector3 target;
    private Vector3 current;
    private Vector3 direction;
    private GameManager gameManager;
    private PlayerController playerController;
    private float distance;
    public float state;
    private float changetime;
    private float iframes;
    private float helt; 
    PlayerController shtbte;
    private float spawnPOS;
    private Vector3 spawnpos;
    public GameObject Axeitem;
    void Start()
    {
        spawnpos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        helt = 16;
        iframes = 750;
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindFirstObjectByType<GameManager>();
        shtbte = FindFirstObjectByType<PlayerController>();
        changetime = 100;
        current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY,0);
    }
    void Update()
    {
        
        if (helt < 1)
        {
            print("die");
            Destroy(gameObject);
        }
        distance = Vector3.Distance(gameObject.transform.position, target);
        if (distance < 4.25)
        {
            if (distance < 1.25)
                state = 3; ///attack
            else
            {
                state = 2;///chase
            }
        }
        else
        {
            state = 1;///patrol
        }

        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        if (state == 2)
        {
            iframes -= 1;
            direction = ((target - transform.position).normalized) * 3;
            transform.position += (direction * Time.deltaTime);
        }

        if (state == 3)
        {
            iframes -= 1;
            if (iframes < 1)
            {
                iframes = 750;
                gameManager.health -= 3;
            }

            direction = ((target - transform.position).normalized) * 3;
            transform.position += (direction * Time.deltaTime) / 2;
        }

        current = transform.position;
        if (state == 1)
        {
            changetime -= 1;
            if (changetime < 1)
            {
                direction = new Vector3(Random.Range(-20, 20), 0);
                changetime = Random.Range(750, 4000);
            }

            transform.position += ((direction * Time.deltaTime) * 0.06f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && shtbte.stbte == 1)
        {
            
            helt -= 4;
            print("helt"+helt);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("magic"))
        {
            helt -= 8;
            print("helt"+helt);
        } 
    }

    private void OnDestroy()
    {
        Instantiate(Axeitem, spawnpos, Quaternion.identity);
    }
}
