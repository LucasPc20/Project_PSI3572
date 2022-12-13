using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private Vector3 _passRotation;
    // Update is called once per frame
    void Update()
    {
        _passRotation = _rotation * Time.deltaTime;
    }

    public Vector3 getPassRotation()
    {
        return _passRotation;
    }
}
