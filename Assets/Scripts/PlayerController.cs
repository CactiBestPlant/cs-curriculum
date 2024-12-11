using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fireball;
    public float xdirection;
    float xspeed;
    float xvector;
    Axeitem has;
    
    private float attacktype;
    private Vector3 spawnpos;
    public float flimit;
    private float mrate;
    
    public float magclear;
    private float magclearclear;
    

    public float ydirection;
    float yspeed;
    float yvector;
    public float playerX;
    public float playerY;
    GameManager Gm;
    public float stbte;
    

    public bool overworld; 

    private void Start()
    {
        mrate = 5;
        magclear = 0;
        flimit = 0;
        Gm = FindAnyObjectByType<GameManager>();
        has = FindFirstObjectByType<Axeitem>();
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

        stbte = 0;

        attacktype = 1;
        

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
        
        mrate -= Time.deltaTime;
        playerX = transform.position.x;
        playerY = transform.position.y;
       
        
        spawnpos = new Vector3(transform.position.x, transform.position.y + 0.5f, 1);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attacktype *= -1;
            print("attack type=" + attacktype);
        }

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

        if (attacktype == -1 && stbte == 1 && flimit < 2 && mrate<1)
        {
            Instantiate(fireball, spawnpos, Quaternion.identity);
            flimit += 1;
            magic clonescript = fireball.GetComponent<magic>();
            mrate = 5;
        }
        
        if (flimit > 1)
        {
            magclear = 1;
            flimit = 0;
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