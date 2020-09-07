using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab;
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
        var create = Instantiate(_ballPrefab, _createPos.position, Quaternion.identity);
        return create;
    }
}
