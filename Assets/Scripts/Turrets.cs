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
                Instantiate(projectileClone, spawnPos, Quaternion.identity);
                projectile cloneScript = projectileClone.GetComponent<projectile>();
                maxProjectiles += 1;
            }
            else
            {
                maxProjectiles = 0;
            }
        }
    }
}

   



   

