using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Unity.VisualScripting;
using Unity.Mathematics;
using System;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] LayerMask clickableLayers;

    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

    public GameObject WaterSpray;
    public GameObject LifeBeam;
    public GameObject Shield;
    public GameObject ColdSpray;
    public GameObject Lightning;
    public GameObject ArcaneBeam;
    public GameObject EarthProjectile;
    public GameObject FireSpray;

    public AudioClip HealingSound;
    public AudioClip ForceFieldSound;
    public AudioClip LightningSound;
    public AudioClip LaserSound;
    public AudioSource WalkingSound;
    public AudioClip DeathSound;

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
            //WalkingSound.Play();
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            agent.destination = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        Attack();

    }

    void HoldToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }


    float BeamDistance()
    {
        Vector2 playerPosition = transform.position;
        Vector3 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.WorldToScreenPoint(mousePosition);

        float BeamVector = Vector2.Distance(playerPosition, mouseWorldPosition);

        return BeamVector;
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameObject water = Instantiate(WaterSpray, transform.position, Quaternion.identity, transform);
                water.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                GameObject life = Instantiate(LifeBeam, transform.position, Quaternion.identity);
                life.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                GameObject cold = Instantiate(ColdSpray, transform.position, Quaternion.identity, transform);
                cold.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject lightning = Instantiate(Lightning, transform.position, Quaternion.identity);
                lightning.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject arcane = Instantiate(ArcaneBeam, transform.position, Quaternion.identity);
                arcane.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                GameObject earth = Instantiate(EarthProjectile, transform.position, Quaternion.identity);
                earth.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));
                Rigidbody rb = earth.GetComponent<Rigidbody>();
                rb.AddForce(earth.transform.forward * 32f, ForceMode.Impulse);
                
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject fire = Instantiate(FireSpray, transform.position, Quaternion.identity, transform);
                fire.transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z));

            }
        }


    }


}
