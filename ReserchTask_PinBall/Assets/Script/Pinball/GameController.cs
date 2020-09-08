using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    #region キャッシュ
    BallController _ballController { get { return BallController.Instance; } }
    StageController _stageController { get { return StageController.Instance; } }
    #endregion

    private void Start()
    {
        //ボールが死んだときの処理
        _ballController._ballDeadCallBack += () => {
            Debug.Log("dead ball");
            //_stageController.Reshot();  
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _stageController.Reshot();
        }
    }
}
