using UnityEngine;

public class Coin : MonoBehaviour
{ 
    GameManager Gm;
    private void Start()
    {
        Gm = FindAnyObjectByType<GameManager>();
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            print("question");
            Gm.coins += 1;
            Destroy(other.gameObject);
            print(Gm.coins);
        }
    }
}