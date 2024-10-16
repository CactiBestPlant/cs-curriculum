using UnityEngine;

public class Turrets : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectileClone;
    public int maxProjectiles;

    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (maxProjectiles < 5)
            {
                GameObject newProjectile = Instantiate(projectileClone, spawnPos, Quaternion.identity);
                projectile cloneScript = newProjectile.GetComponent<projectile>();
                // Optionally initialize cloneScript if needed
                maxProjectiles++;
            }
            else
            {
                maxProjectiles = 0; // Consider other logic here if needed
            }
        }
    }
}