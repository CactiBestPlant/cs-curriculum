using UnityEngine;

public class magic : MonoBehaviour
{
    private float speed;
    private PlayerController pcode;

    private float presence;
   
    void Start()
    {
        pcode = FindAnyObjectByType<PlayerController>();
        presence = 300;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += pcode.forwardDirection * speed * Time.deltaTime;
        presence -= Time.deltaTime;
        if (presence <= 0)
        {
            Destroy(gameObject);
        }

        if (pcode.magclear == 1)
        {
            Destroy(gameObject);
        }
    }
}
