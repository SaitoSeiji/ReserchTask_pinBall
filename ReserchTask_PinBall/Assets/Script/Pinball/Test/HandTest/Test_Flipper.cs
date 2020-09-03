using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Flipper : MonoBehaviour
{
    [SerializeField] Flipper _flipper;
    [SerializeField,Range(0,1)] int _clickSide;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(_clickSide))
        {
            _flipper.FlipOn();
        }
        if (Input.GetMouseButtonUp(_clickSide))
        {
            _flipper.FlipOff();
        }
    }
}
