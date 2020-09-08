using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stage;
public class Test_shotter : MonoBehaviour
{
    [SerializeField] Shotter _shotter;
    [SerializeField] GameObject _target;

    [ContextMenu("shot")]
    void Test_shot()
    {
        _shotter.Shot(_target);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _target= _shotter.SetBall();
            _shotter.Shot(_target);
        }
    }
}
