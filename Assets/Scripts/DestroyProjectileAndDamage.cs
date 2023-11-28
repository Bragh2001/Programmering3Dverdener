using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileAndDamage : MonoBehaviour
{
    public GameObject parent;

    bool DoneDamage;

    GameObject enemy;
    EnemyController enemyScript;

    GameObject player;
    PlayerController playerScript;

    void Start()
    {
        StartCoroutine(Wait());

        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyScript = enemy.GetComponent<EnemyController>();
        }

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(DoneDamage == false && parent != collision.gameObject)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                enemyScript.TakeDamage(20);
                DoneDamage = true;
            }

            if (collision.gameObject.tag == "Player")
            {
                playerScript.TakeDamage(5);
                DoneDamage = true;
            }
        }

    }
}
