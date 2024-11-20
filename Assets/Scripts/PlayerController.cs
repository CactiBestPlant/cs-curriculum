using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    float xdirection;
    float xspeed;
    float xvector;
    Axeitem has;

    float ydirection;
    float yspeed;
    float yvector;
    public float playerX;
    public float playerY;
    GameManager Gm;
    public float stbte;

    public bool overworld; 

    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();
        has = FindFirstObjectByType<Axeitem>();
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

        stbte = 0;

        xdirection = 0;
        xspeed = 5;
        xvector = 0;

        ydirection = 0;
        yspeed = 5;
        yvector = 0;

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    private void Update()
    {
        playerX = transform.position.x;
        playerY = transform.position.y;
        
        

        if (Input.GetMouseButton(0))
        {
           // print("state is one");
            stbte = 1;
            
        }
        else
        {
            //print("state is 2");
            stbte = 0;
        }
      

        xdirection = Input.GetAxis("Horizontal");
        xvector = xdirection * xspeed * Time.deltaTime ;
        transform.Translate(xvector, 0, 0);

        ydirection = Input.GetAxis("Vertical");
        yvector = ydirection * yspeed * Time.deltaTime;
        transform.Translate(0, yvector, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (stbte == 1 && other.gameObject.CompareTag("door"))
        {
            Destroy(other.gameObject);
        }
    }


    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}