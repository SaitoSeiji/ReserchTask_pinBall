using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Stage
{
    public class Flipper : MonoBehaviour
    {

        [SerializeField] float spring = 40000;
        [SerializeField] float openAngle = 60; // 開く角度
        [SerializeField] float closeAngle = 0; // 閉じる角度


        [SerializeField] HingeJoint _hingeJoint;
        JointSpring _jointSpring;

        private void Start()
        {
            _jointSpring = _hingeJoint.spring;
        }


        public void FlipOn()
        {
            _jointSpring.spring = spring;
            _jointSpring.targetPosition = openAngle;
            _hingeJoint.spring = _jointSpring;
        }

        public void FlipOff()
        {
            _jointSpring.spring = spring;
            _jointSpring.targetPosition = closeAngle;
            _hingeJoint.spring = _jointSpring;
        }
    }
}