using UnityEngine;

public class Axeitem : MonoBehaviour
{
    public float hasaxe;
    void Start()
    {
        hasaxe = 0;
    }

   
    void Update()
    {
        if (hasaxe > 0)
        {
            print("Simon is a homosexual");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("question2");
            hasaxe += 1;
            Destroy(gameObject);
            print(" Axe Obtained");
        }
    }
}
