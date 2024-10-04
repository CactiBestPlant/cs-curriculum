using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 5f; // Speed of the projectile
    private Vector3 targetPosition;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Method to set the target position
    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        Vector3 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * speed; // Set the velocity towards the target
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if it collides with a target (like the player)
        if (collision.gameObject.CompareTag("Player"))
        {
             //Optional: Add effects or damage logic here
             //ddExample: collision.gameObject.GetComponent<Player>().TakeDamage(damageAmount);
            Debug.Log("Hit Player!");
        }

        // Destroy the projectile on collision
        Destroy(gameObject);
    }

    private void Update()
    {
        // Optional: Destroy the projectile after some time
        Destroy(gameObject, 5f); // Destroys the projectile after 5 seconds
    }
}



