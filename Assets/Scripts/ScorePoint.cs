using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [HideInInspector] public bool _touched;
    void Update()
    {
        if(_touched) Destroy(gameObject);
    }
}
