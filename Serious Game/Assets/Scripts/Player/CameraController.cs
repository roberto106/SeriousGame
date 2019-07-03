using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _playerGameObject;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - _playerGameObject.transform.position;
    }

    void LateUpdate()
    {
        transform.position = _playerGameObject.transform.position + offset;
    }
}
