using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text _counter;

    void Update ()
    {
        _counter.text = $"{Slingshot.cnt} \n шариков кинуто";
    }
}
