using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    public class Shotter : MonoBehaviour
    {
        [SerializeField] Transform _createPos;
        [SerializeField] Vector2 _direction;
        [SerializeField] float _power;

        [ContextMenu("Shot")]
        public void Shot(GameObject obj)
        {
            var rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(_direction.normalized * _power, ForceMode.Impulse);
        }

        public GameObject SetBall()
        {
            var create = BallController.Instance.CreateBall();
            create.transform.position = _createPos.position;
            return create;
        }
    }
}
