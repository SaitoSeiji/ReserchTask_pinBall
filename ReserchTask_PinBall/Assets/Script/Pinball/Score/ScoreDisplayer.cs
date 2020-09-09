using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    void Start()
    {
        ScoreController.Instance._scoreAddCalback += () =>
         {
             _scoreText.text = $"score: {ScoreController.Instance._NowScore}";
         };
    }

}
