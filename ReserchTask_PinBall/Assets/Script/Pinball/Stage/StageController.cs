using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stage;

public class StageController : SingletonMonoBehaviour<StageController>
{
    [SerializeField] Shotter _shotter;
    public Shotter _Shotter { get { return _shotter; } }

    [SerializeField] GameObject _lock;

    public void SetLockActive(bool isLock)
    {
        _lock.SetActive(isLock);
    }

    public void Reshot()
    {
        var ball=_shotter.SetBall();
        _shotter.Shot(ball);
    }
}
