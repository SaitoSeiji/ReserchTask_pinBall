using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_stick : MonoBehaviour
{
    [SerializeField] StickController str;
    [SerializeField] GameObject pushTarget;

    [SerializeField,Range(0,360)]float _rotation;

    [ContextMenu("test_setPos")]
    void Test_setPos()
    {
        str.PrepareStick(pushTarget.transform.position, _rotation);
    }
    [ContextMenu("test_push")]
    void Test_push()
    {
        str.Push();
    }
}
