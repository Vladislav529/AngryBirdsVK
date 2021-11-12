using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject launch;
    void OnMouseEnter()
    {
        launch.SetActive(true);
    }
    void OnMouseExit()
    {
        launch.SetActive(false);
    }
}
