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
        presence = 300;
        speed = 0.05f;
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

        if (pcode.magclear == 1)
        {
            Destroy(gameObject);
            pcode.magclear = 0;
        }
    }
}
