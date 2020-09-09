using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheckObject : MonoBehaviour
{
    ScoreObjectController _scoreObjeCtrl { get { return ScoreController.Instance._scoreObjCtrl; } }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ScoreObject")
        {
            _scoreObjeCtrl.AddScoreObj(col.gameObject);
        }
    }

}
