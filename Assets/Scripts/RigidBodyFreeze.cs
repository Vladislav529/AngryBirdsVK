using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (rigidBody != null)
            rigidBody.Sleep();
    }
}
