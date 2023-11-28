using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Unity.VisualScripting;
using Unity.Mathematics;
using System;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.IO;

public class PlayerController : MonoBehaviour
{
    // This script controls the players movement, attack and health

    // Navigation variables
    NavMeshAgent agent;
    [SerializeField] LayerMask clickableLayers;

    // Spawn point for projectile instantiation
    public GameObject spawnPoint;

    // Health-related variables
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

    // Projectile prefabs
    public GameObject waterSpray;
    public GameObject lifeBeam;
    public GameObject shield;
    public GameObject coldSpray;
    public GameObject lightningBeam;
    public GameObject arcaneBeam;
    public GameObject earthProjectile;
    public GameObject fireSpray;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Awake()
    {
        // Get reference to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check for left mouse button and move
        if (Input.GetKey(KeyCode.Mouse0))
        {
            HoldToMove();
        }

        // Check for left mouse button released and stop in position
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            agent.destination = transform.position;
        }

        Attack();

    }

    void HoldToMove()
    {
        // Move the player to the mouse position on the plane and face the destination
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health and update the health bar
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        // If health drops to zero or below, destroy the player after a short delay
        if (currentHealth <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }

    void DestroyPlayer()
    {
        // Destroy the player GameObject
        Destroy(gameObject);
    }

    void Attack()
    {
        // Raycast to determine the target position based on mouse input
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            // Instantiate projectiles based on key input
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Water Spray
                GameObject water = Instantiate(waterSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                water.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                water.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                // Life Beam
                GameObject life = Instantiate(lifeBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                life.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                // Cold Spray
                GameObject cold = Instantiate(coldSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                cold.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                cold.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Lightning Beam
                GameObject lightning = Instantiate(lightningBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                lightning.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Arcane Beam
                GameObject arcane = Instantiate(arcaneBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                arcane.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // Earth Projectile
                GameObject earth = Instantiate(earthProjectile, spawnPoint.transform.position, Quaternion.identity);
                earth.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                earth.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));
                Rigidbody rb = earth.GetComponent<Rigidbody>();
                rb.AddForce(earth.transform.forward * 32f, ForceMode.Impulse);
                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Fire Spray
                GameObject fire = Instantiate(fireSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                fire.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                fire.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }
        }


    }


}
