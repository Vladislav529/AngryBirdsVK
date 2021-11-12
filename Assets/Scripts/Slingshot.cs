using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectTile;

    [Header("Set Dynamically")]
    public GameObject launchPoint, projectTile;
    public Vector3 launchPos; // хранит координаты launchPoint
    public bool aimMode; // True, когда игрок нажимает кнопку мыши

    void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }
    void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }
    void Awake()
    {
        Transform launchPointTrans = transform.Find("Launch"); // найдёт дочерний объект с таким названием
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position; // установка координат для launchPos
    }
    void OnMouseDown()
    {
        aimMode = true;
        projectTile = Instantiate(prefabProjectTile) as GameObject;
        projectTile.transform.position = launchPos;
        projectTile.GetComponent<Rigidbody>().isKinematic = true;
    }
}