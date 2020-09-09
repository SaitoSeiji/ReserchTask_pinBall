using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreController : SingletonMonoBehaviour<ScoreController>
{
    [SerializeField] int _nowScore;
    public int _NowScore { get { return _nowScore; } }

    #region キャッシュ
    public ScoreObjectController _scoreObjCtrl { get; private set; }

    #endregion

    public Action _scoreAddCalback;

    // Start is called before the first frame update
    void Start()
    {
        _scoreObjCtrl = new ScoreObjectController();
    }

    // Update is called once per frame
    void Update()
    {
        var addScore= _scoreObjCtrl.CalcWaitScores();
        if (addScore > 0)
        {
            _nowScore += addScore;
            _scoreAddCalback?.Invoke();
        }
    }
}
