using UnityEngine;

public class Coin : MonoBehaviour
{ 
    GameManager Gm;
    private void Start()
    {
        Gm = FindObjectOfType<GameManager>();
    }

    
   private void Update()
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Gm.coins += 1;
                print(Gm.coins);
            }
        }
    }
}
