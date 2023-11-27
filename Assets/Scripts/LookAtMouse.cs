using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{

    [SerializeField] LayerMask clickableLayers;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {

            transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.parent.position.y, hit.point.z));

        }
    }
}
