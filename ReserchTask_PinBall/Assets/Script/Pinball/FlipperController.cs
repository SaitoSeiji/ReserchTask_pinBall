using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] Flipper _leftFlipper;
    [SerializeField] Flipper _rightFlipper;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _leftFlipper.FlipOn();
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _leftFlipper.FlipOff();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _rightFlipper.FlipOn();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            _rightFlipper.FlipOff();
        }
    }
}
