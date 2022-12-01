using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Vector3 _v;
    [HideInInspector] BulletShooter _bs;
    void Start()
    {
        _bs = FindObjectOfType<BulletShooter>();
        _v = new Vector3(_bs.x,_bs.y).normalized * _bs._bulletSpeed;
        StartCoroutine(Direction());
    }

    IEnumerator Direction()
    {
        float _accumulator = 0f;
        while(_accumulator<5f)
        {
            transform.position += _v * Time.deltaTime;
            _accumulator += Time.deltaTime;
            yield return null;
        }

    }
}
