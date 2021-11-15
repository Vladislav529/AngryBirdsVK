using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    static public GameObject point;

    [Header("Set in Inspector")]
    public float relief = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float cameraZ;

    void Awake()
    {
        cameraZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        // if (point == null) return;
        // Vector3 destination = point.transform.position;
        Vector3 destination;
        if (point == null) 
            destination = Vector3.zero;
        else
        {
            destination = point.transform.position;
            if (point.CompareTag("ProjectTile") && point.GetComponent<Rigidbody>().IsSleeping())
            {
                point = null;
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // определить точку между текущим местоположением и destination
        destination = Vector3.Lerp(transform.position, destination, relief);
        destination.z = cameraZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
