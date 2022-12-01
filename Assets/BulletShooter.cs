using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _shootingInterval = 2f;
    [HideInInspector] public float x, y, z;
    public float _bulletSpeed = 3f;
    float _accumulator = 0f;

    void Update()
    {
        if(_accumulator>_shootingInterval)
        {
            Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _accumulator = 0f;
        }
        _accumulator += Time.deltaTime;

        
    }
}
