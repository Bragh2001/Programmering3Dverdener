using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileAndDamage : MonoBehaviour
{
    // This script is used to destoy projectiles after a short time and give damage to player and enemy if they are hit.

    // Reference to the parent GameObject
    public GameObject parent;

    // Bool to ensure damage is only done once
    bool DoneDamage;

    // References to enemy GameObject and its controller script
    GameObject enemy;
    EnemyController enemyScript;

    // Reference to player GameObject and its controller script
    GameObject player;
    PlayerController playerScript;

    void Start()
    {
        // Start a coroutine to destroy the projectile after a delay
        StartCoroutine(Wait());

        // Find enemy if they are present in the scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyScript = enemy.GetComponent<EnemyController>();
        }

        // Find the player
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Coroutine to wait for a specified time before destroying the projectile
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    // Handle collision events with other GameObjects
    private void OnCollisionEnter(Collision collision)
    {
        // Check if damage has already been done and the collided GameObject is not the parent
        if (DoneDamage == false && parent != collision.gameObject)
        {
            // If the collided GameObject is an enemy, damage the enemy
            if (collision.gameObject.tag == "Enemy")
            {
                enemyScript.TakeDamage(20);
                DoneDamage = true;
            }

            // If the collided GameObject is the player, damage the player
            if (collision.gameObject.tag == "Player")
            {
                playerScript.TakeDamage(5);
                DoneDamage = true;
            }
        }

    }
}
