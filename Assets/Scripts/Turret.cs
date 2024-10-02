using System;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectilePrefab;
    private GameObject target;

    private void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject clone; 
            clone = Instantiate(projectilePrefab,spawnPos, Quaternion.identity);
            projectile clonescript=clone.GetComponent<projectile>();
            clonescript = other.gameObject.transform.position;
        }
    }

    private void Update()
    {
        
    }
}

