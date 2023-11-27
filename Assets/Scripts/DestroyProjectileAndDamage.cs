using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectileAndDamage : MonoBehaviour
{

    GameObject Enemy;
    EnemyMovement EnemyScript;

    GameObject Player;
    PlayerController PlayerScript;

    void Start()
    {
        StartCoroutine(Wait());

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyScript = Enemy.GetComponent<EnemyMovement>();

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerController>();
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
            EnemyScript.TakeDamage(20);
        }

        if (collision.gameObject.tag == "Player")
        {
            PlayerScript.TakeDamage(5);
        }

    }
}
