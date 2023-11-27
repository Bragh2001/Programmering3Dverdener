using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            /*var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null )
            {
                healthComponent.TakeDamage(10);
            }*/
        }
    }

}
