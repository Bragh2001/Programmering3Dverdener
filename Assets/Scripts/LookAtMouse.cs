using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // This script makes the spray elements in particle systems look in the direction of the mouse.

    // Layer mask to define which layers can be considered as clickable
    [SerializeField] LayerMask clickableLayers;

    void Update()
    {
        // Raycast to determine the target position based on mouse input
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            // Make the particle system look at the point and adjust the height to match the player's position
            transform.LookAt(new Vector3(hit.point.x, hit.point.y + transform.parent.position.y, hit.point.z));

        }
    }
}
