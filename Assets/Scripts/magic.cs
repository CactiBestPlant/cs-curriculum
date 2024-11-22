using UnityEngine;

public class magic : MonoBehaviour
{
    private float speed;
    private PlayerController limit;

    private float presence;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        presence = 5;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed,0,0);
        presence -= Time.deltaTime;
        if (presence <= 0)
        {
            Destroy(gameObject);
        }

        if (limit.flimit > 1)
        {
            Destroy(gameObject);
        }
    }
}
