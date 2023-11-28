using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    // This script is controlling the enemy

    // Health-related variables
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

    // Navigation and targeting variables
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public GameObject projectile;

    // Attack variables
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // Sight and attack range variables
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        // Find the player and set it as the target
        Transform playerTransform = GameObject.Find("Player").transform;
        player = playerTransform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // If player is in sight but not in attack range, chase the player
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        // If player is both in sight and attack range, attack the player
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    void ChasePlayer()
    {
        // Set the destination for the NavMeshAgent to the player's position
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        // Stop moving
        agent.SetDestination(transform.position);

        // Face the player
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Instantiate and configure the projectile
            GameObject arrow = Instantiate(projectile, transform.position, Quaternion.identity);
            arrow.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
            arrow.transform.Rotate(new Vector3(-90,0, 0));
            Rigidbody rb = arrow.GetComponent<Rigidbody>();

            // Apply force to the projectile
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            // Set the attack cooldown
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }

    void ResetAttack()
    {
        // Reset the attack cooldown
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        // Reduce health and update the health bar
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        // If health drops to zero or below, destroy the enemy after a short delay
        if (currentHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    void DestroyEnemy()
    {
        // Destroy the enemy GameObject
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Draws visualizations for attack and sight range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
