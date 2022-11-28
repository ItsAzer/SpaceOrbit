using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointSpawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnObject;
    [SerializeField] private float _timeLimit = 0.3f, _accumalator = 0f;
    void Update()
    {
        if(_accumalator>_timeLimit)
        {
            Instantiate(_spawnObject);
            _spawnObject.transform.position = transform.position;
            _spawnObject.transform.rotation = transform.rotation;
            _accumalator = 0f;
        }
        _accumalator+=Time.deltaTime;    
    }
}
