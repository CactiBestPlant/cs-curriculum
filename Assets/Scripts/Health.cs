using UnityEngine;

public class Health : MonoBehaviour
{ 
    GameManager Gm; 
    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            Gm.health -= 1;
            print(Gm.health);
        }
    }
}
