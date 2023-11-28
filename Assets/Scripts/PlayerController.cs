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
    NavMeshAgent agent;
    [SerializeField] LayerMask clickableLayers;

    public GameObject spawnPoint;

    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

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
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            HoldToMove();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            agent.destination = transform.position;
        }

        Attack();

    }

    void HoldToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject water = Instantiate(waterSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                water.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                water.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject life = Instantiate(lifeBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                life.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject cold = Instantiate(coldSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                cold.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                cold.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject lightning = Instantiate(lightningBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                lightning.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject arcane = Instantiate(arcaneBeam, spawnPoint.transform.position, Quaternion.identity, transform);
                arcane.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject earth = Instantiate(earthProjectile, spawnPoint.transform.position, Quaternion.identity);
                earth.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                earth.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));
                Rigidbody rb = earth.GetComponent<Rigidbody>();
                rb.AddForce(earth.transform.forward * 32f, ForceMode.Impulse);
                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject fire = Instantiate(fireSpray, spawnPoint.transform.position, Quaternion.identity, transform);
                fire.GetComponent<DestroyProjectileAndDamage>().parent = this.gameObject;
                fire.transform.LookAt(new Vector3(hit.point.x, hit.point.y + 1f, hit.point.z));

            }
        }


    }


}
