using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreObjectController
{
    Dictionary<GameObject, ScoreObject> _scoreObjectDec = new Dictionary<GameObject, ScoreObject>();

    Queue<GameObject> _scoreCalcWaits=new Queue<GameObject>();

    public ScoreObjectController()
    {
        var scoreList = GetSceneScoreObjs();
        foreach (var obj in scoreList)
        {
            _scoreObjectDec.Add(obj.gameObject, obj);
        }
    }


    public void AddScoreObj(GameObject obj)
    {
        _scoreCalcWaits.Enqueue(obj);
    }

    public int CalcWaitScores()
    {
        if (_scoreCalcWaits.Count >= 2) Debug.Log("manyhits");
        int result = 0;
        while (_scoreCalcWaits.Count > 0)
        {
            var target = _scoreCalcWaits.Dequeue();
            var targetScore = _scoreObjectDec[target];

            result += targetScore._Score;
        }

        return result;
    }

    //重いから気を付けて
    List<ScoreObject> GetSceneScoreObjs()
    {
        return GameObject.FindObjectsOfType<ScoreObject>().ToList();
    }
}
