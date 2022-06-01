using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 direction;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider != null)
                {
                    direction = hitInfo.point - player.transform.position;
                    Vector3 dir = new Vector3(player.transform.rotation.x,direction.y, player.transform.rotation.z);
                    player.transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.rotation.x, hitInfo.point.y, player.transform.rotation.z));



                }
            }

        }
    }
}
