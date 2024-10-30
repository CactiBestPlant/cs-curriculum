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
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            print("question2");
            hasaxe = 1;
            Destroy(other.gameObject);
            print(" Axe Obtained");
        }
    }
}
