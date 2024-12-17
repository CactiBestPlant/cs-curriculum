using Unity.VisualScripting;
using UnityEngine;

public class magic : MonoBehaviour
{
    private float speed;
    private PlayerController pcode;
    private float fdirectionx;
    private float fdirectiony;

    private float presence;
   
    void Start()
    {
       
        pcode = FindAnyObjectByType<PlayerController>();
        fdirectionx = pcode.xdirection;
        fdirectiony = pcode.ydirection;
        presence = 100;
        speed = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(fdirectionx * speed, fdirectiony*speed,0) ; 
        presence -= Time.deltaTime;
        if (presence <= 0)
        {
            Destroy(gameObject);
        }

        if (pcode.attacktype == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    


}

