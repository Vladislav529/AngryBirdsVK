using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabProjectTile;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint, projectTile;
    public Vector3 launchPos; // ������ ���������� launchPoint
    public bool aimMode; // True, ����� ����� �������� ������ ����

    public static int cnt = 0;
    public static Slingshot instance;
    private Rigidbody projectTileRigidBody;

    public static Vector3 LAUNCH_POS
    {
        get
        {
            return instance == null
                ? Vector3.zero
                : instance.launchPos;
        }
    }

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
        instance = this;
        Transform launchPointTrans = transform.Find("Launch"); // ����� �������� ������ � ����� ���������
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position; // ��������� ��������� ��� launchPos
    }
    void OnMouseDown()
    {
        aimMode = true;
        projectTile = Instantiate(prefabProjectTile) as GameObject;
        projectTile.transform.position = launchPos;
        projectTile.GetComponent<Rigidbody>().isKinematic = true;

        projectTileRigidBody = projectTile.GetComponent<Rigidbody>();
        projectTileRigidBody.isKinematic = true;
    }
    void Update() {
        // transform.LookAt(projectTile.transform);

        if (!aimMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projectTilePos = launchPos + mouseDelta; // ������� ������ � ����� �������
        projectTile.transform.position = projectTilePos;

        if (Input.GetMouseButtonUp(0)) // ��������� ������
        {
            aimMode = false;
            cnt += 1;
            projectTileRigidBody.isKinematic = false;
            projectTileRigidBody.velocity = -mouseDelta * velocityMult;
            FollowingCamera.point = projectTile;
            projectTile = null;
        }
    }
}