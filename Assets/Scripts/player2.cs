using UnityEngine;

public class PlatScript : MonoBehaviour
{
    Collider2D collider2d;
    Rigidbody2D rb;
    public float length;
    public int jump;
    public float playerX;
    public float playerY;
    public int canJump;
    void Start()
    {
        jump = 0;
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        length = 1f; // Length of the ray to check for ground
    }

    void Update()
    {
        playerX = transform.position.x;
        playerY = transform.position.y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = 1;  // Set jump flag when Space is pressed
        }
        else
        {
            jump = 0;  // Reset jump flag when Space is released
        }

        // Raycasts to check if the player is grounded
        Vector2 leftRayOrigin = new Vector2(transform.position.x - collider2d.bounds.extents.x, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + collider2d.bounds.extents.x, transform.position.y);

        // Perform the raycasts downward
        RaycastHit2D leftRay = Physics2D.Raycast(leftRayOrigin, Vector2.down, length);
        RaycastHit2D rightRay = Physics2D.Raycast(rightRayOrigin, Vector2.down, length);

        // Draw the rays for debugging (only draw in Scene view, not in game)
        Debug.DrawRay(leftRayOrigin, Vector2.down * length, Color.red);
        Debug.DrawRay(rightRayOrigin, Vector2.down * length, Color.red);

        // Check if either ray hits a collider (indicating ground)
        if ((leftRay.collider != null || rightRay.collider != null) && jump == 1)
        {
            // If the ray hits something and the player presses jump, apply the jump force
            rb.AddForce(Vector2.up * 350); // Jump force
        }

        if (leftRay.collider != null || rightRay.collider != null)
        {
            canJump = 1;
        }
        else canJump = 0;
    }
}