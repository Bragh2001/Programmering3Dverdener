using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x + 0.5f, target.transform.position.y - 1f, target.transform.position.z + 0.5f);
    }
}
