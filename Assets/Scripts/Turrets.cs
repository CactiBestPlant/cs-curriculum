using UnityEngine;

public class Turrets : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectilePrefab;
    public float fireRate = 1f; // Time in seconds between shots
    private float nextFireTime = 0f;

    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextFireTime)
            {
                FireProjectile(other.transform.position);
                nextFireTime = Time.time + fireRate; // Set next fire time
            }
        }
    }

    private void FireProjectile(Vector3 targetPosition)
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        projectile cloneScript = clone.GetComponent<projectile>();

        if (cloneScript != null)
        {
            cloneScript.SetTarget(targetPosition);
        }
    }
}



   

