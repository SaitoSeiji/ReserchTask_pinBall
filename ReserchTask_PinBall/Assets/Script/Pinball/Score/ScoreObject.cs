using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//拡張する場合は抽象クラスにしたい
public class ScoreObject : MonoBehaviour
{
    [SerializeField] int _score;
    public int _Score { get { return _score; } }
}
