using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BallData
{
    public enum State
    {
        Before,//発射～lock通過まで
        Play,//途中
        Dead//死亡
    }
    public State _state { get; set; }
    public Transform _tr { get; private set; }

    public BallData(Transform tr)
    {
        _state = State.Before;
        _tr = tr;
    }
}

public class BallController : SingletonMonoBehaviour<BallController>
{

    [SerializeField] GameObject _ballPrefab;
    [SerializeField] float _ballStartHeight;
    [SerializeField] float _ballDeadHeight;

    [SerializeField,Space(20)] List<Transform> _ballTrList = new List<Transform>();//確認用
    List<BallData> _ballDetaList = new List<BallData>();

    public Action _ballDeadCallBack;
    private void Update()
    {
        UpdateDataList();

        _ballTrList = _ballDetaList.Select(x => x._tr).ToList();
    }

    //データリストの更新
     //もうちょい完結に書きたい
    void UpdateDataList()
    {
        bool anyUpdate = false;
        //データの状態の更新
        foreach (var bdata in _ballDetaList)
        {
            switch (bdata._state)
            {
                case BallData.State.Before:
                    if (!IsInStartArea(bdata._tr))
                    {
                        bdata._state = BallData.State.Play;
                    }
                    anyUpdate = true;
                    break;
                case BallData.State.Play:
                    if (IsBallDead(bdata._tr))
                    {
                        bdata._state = BallData.State.Dead;
                        anyUpdate = true;
                    }
                    break;
            }
        }

        //リストの更新
        if (anyUpdate)
        {
            var inStartList = _ballDetaList.Where(x => x._state == BallData.State.Before);
            var isLock = (inStartList.Count() == 0);
            StageController.Instance.SetLockActive(isLock);
            var deadList = _ballDetaList.Where(x => x._state == BallData.State.Dead).ToList();
            for (int i = deadList.Count() - 1; i >= 0; i--) BallDeadAction(deadList[i]);
        }
    }

    public GameObject CreateBall()
    {
        var obj= Instantiate(_ballPrefab);
        var bdata = new BallData(obj.transform);
        _ballDetaList.Add(bdata);
        return obj;
    }

    //ボールがスタートエリアにいるかどうかの判定をするもの
    bool IsInStartArea(Transform tr)
    {
        return tr.position.y < _ballStartHeight;
    }
    //ボールが死んだかどうかの判定をするもの
    bool IsBallDead(Transform checkTr)
    {
        return checkTr.position.y < _ballDeadHeight;
    }
    //ボールが死んだときに呼ばれる
    void BallDeadAction(BallData deadBall)
    {
        _ballDeadCallBack?.Invoke();
        _ballDetaList.Remove(deadBall);
        Destroy(deadBall._tr.gameObject);
    }
}
