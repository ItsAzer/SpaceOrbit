using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Vector3 _v;
    void Start()
    {
        StartCoroutine(Direction());
    }

    IEnumerator Direction()
    {
        float _accumulator = 0f;
        while(_accumulator<7f)
        {
            transform.position += _v * Time.deltaTime;
            _accumulator += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);

    }
}
