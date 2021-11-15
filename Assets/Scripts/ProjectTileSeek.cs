using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileSeek : MonoBehaviour
{
    public static ProjectTileSeek instance;

    [Header("Set in Inspector")]
    public float minDistance = 0.01f;

    public LineRenderer _renderer;
    public GameObject _point;
    private List<Vector3> points;


    private void Awake()
    {
        instance = this;
        _renderer = GetComponent<LineRenderer>();
        _renderer.enabled = false;
        points = new List<Vector3>();
    }


    public GameObject point
    {
        get
        {
            return _point;
        }
        set
        {
            _point = value;
            if (point == null)
            {
                _renderer.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }
    public Vector3 lastPoint
    {
        get {
            return points == null || points.Count == 0 ? Vector3.zero : points[points.Count - 1];
        }
    }
    public void Clear()
    {
        _point = null;
        _renderer.enabled = false;
        points = new List<Vector3>();
    }
    private void AddPoint()
    {
        Vector3 pt = _point.transform.position;
        if (points.Count > 0 && (pt - lastPoint).magnitude < minDistance)
            return;
        if (points.Count == 0)
        {
            points.Add(pt);
            points.Add(Slingshot.LAUNCH_POS);
            _renderer.positionCount = 2;
            _renderer.SetPosition(0, points[0]);
            _renderer.SetPosition(1, points[1]);
            _renderer.enabled = true;
        }
        else
        {
            points.Add(pt);
            _renderer.positionCount = points.Count;
            _renderer.SetPosition(points.Count - 1, lastPoint);
        }
    }
    private void FixedUpdate()
    {
        if (_point == null)
        {
            if (FollowingCamera.point != null
                && FollowingCamera.point.CompareTag("ProjectTile"))
            {
                point = FollowingCamera.point;
            }
            else return;
        }
        AddPoint();
        if (FollowingCamera.point == null)
        {
            point = null;
        }
    }
}
