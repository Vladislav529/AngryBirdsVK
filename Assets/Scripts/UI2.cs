using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI2 : MonoBehaviour
{
    [SerializeField]
    private Text _timing;

    void Update()
    {
        _timing.text = $"С запуска программы прошло \n {Time.realtimeSinceStartup}";
    }
}
