using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileAndDamage : MonoBehaviour
{

    GameObject enemy;
    EnemyController enemyScript;

    GameObject player;
    PlayerController playerScript;

    void Start()
    {
        StartCoroutine(Wait());

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = enemy.GetComponent<EnemyController>();

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
        if (collision.gameObject.tag == "Enemy") 
        { 
            enemyScript.TakeDamage(20);
        }

        if (collision.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(5);
        }

    }
}
