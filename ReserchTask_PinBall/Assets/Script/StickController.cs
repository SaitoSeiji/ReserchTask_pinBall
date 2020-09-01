using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField] GameObject _Stick;
    Transform _stickTr;
    Rigidbody _rb;

    [SerializeField] float _pushSpeed;

    [SerializeField] Vector3 _targetPos;

    [SerializeField]bool isPush;
    #region MonoBehaviour基本関数
    private void Start()
    {
        _stickTr = _Stick.transform;
        _rb = _Stick.GetComponent<Rigidbody>();
    }

    //ちょっとフォロースルー欲しい
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            isPush = false;
            _rb.velocity = Vector3.zero;
        }
    }
    #endregion
    //現状角度指定を想定していない
    Vector3 GetPreparePosition()
    {
        var pos = _targetPos;
        pos -= _stickTr.up *7;
        return pos;
    }
    #region publick
    public void PrepareStick(Vector3 pos, float rotation)
    {
        _targetPos = pos;
        _stickTr.rotation = Quaternion.Euler(0,rotation,-90);
        _stickTr.position=GetPreparePosition();
        _Stick.SetActive(true);
    }


    public void Push()
    {
        isPush = true;
        _rb.velocity = _stickTr.up.normalized*_pushSpeed;
    }

    public void Back()
    {

    }
    #endregion
}
