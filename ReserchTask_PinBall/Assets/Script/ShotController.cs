using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] StickController _stick;
    [SerializeField] Camera cam;

    public enum ShotState
    {
        NONE,
        PREPAREPOS,
        SHOT
    }
    [SerializeField]ShotState _shotState=ShotState.NONE;

    private void Update()
    {
        switch (_shotState)
        {
            case ShotState.PREPAREPOS://角度指定
                var rotation = CalcStickRotation();
                SetStick(rotation);
                if (Input.GetMouseButtonDown(0))
                {
                    _shotState = ShotState.SHOT;
                }
                break;
            case ShotState.SHOT:
                if (Input.GetMouseButtonDown(0))
                {
                    _shotState = ShotState.NONE;
                    Shot();
                }
                break;
        }
    }

    #region local

    float CalcStickRotation()
    {
        var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tempVec = (_ball.transform.position - mousepos).normalized;
        Vector2 vec = new Vector2(tempVec.x, tempVec.z);
        var rotation = Vector3.Angle(new Vector3(1, 0, 0), vec.normalized);
        if (vec.y > 0) rotation = 360 - rotation;
        return rotation;
    }

    void SetStick(float rotation)
    {
        _stick.PrepareStick(_ball.transform.position,rotation);
    }

    void Shot()
    {
        _stick.Push();
    }
    #endregion


}
