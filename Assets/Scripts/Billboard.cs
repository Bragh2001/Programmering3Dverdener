using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //This script is on the player and enemy healthbar canvases
    public Transform target;

    private void Update()
    {
        //Gets the position of the healthbar to be placed under and in front of the target (The targets set in the inspector are the player and enemy).
        transform.position = new Vector3(target.transform.position.x + 0.5f, target.transform.position.y - 1f, target.transform.position.z + 0.5f);
    }
}
