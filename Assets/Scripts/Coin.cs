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
        print("aaaaahhhh");
        if (other.gameObject.CompareTag("Coin"))
        {
            Gm.coins += 1;
            Destroy(other.gameObject);
            print(Gm.coins);
        }
    }
}
