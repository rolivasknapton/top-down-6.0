using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField] private float _shakeForce = 1f;
    private CinemachineImpulseSource _impulsource;

    private void Awake()
    {
        _impulsource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shake(Vector2 direction)
    {
        _impulsource.GenerateImpulseWithVelocity(-direction * _shakeForce);
    }

}
