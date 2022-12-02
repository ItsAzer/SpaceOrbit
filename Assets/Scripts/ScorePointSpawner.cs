using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointSpawner : MonoBehaviour
{
    [SerializeField] GameObject _spawnObject, _center;
    private float _lookAngle;
    [HideInInspector] public int _numberOfPoints = 0;
    void Start()
    {
        float x, y, z;
        for(float i=0f;i<6.28;i=i+0.4f)
        {
            _numberOfPoints++;
            x =  Mathf.Cos(i) * FindObjectOfType<ShipBehaviour>()._amplitude;
            y = Mathf.Sin(i) * FindObjectOfType<ShipBehaviour>()._amplitude;
            z = 2;
            _spawnObject.transform.position = new Vector3(x, y,z);

            Vector3 v = (-_center.transform.position + _spawnObject.transform.position).normalized;
            _lookAngle = 90 + Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;
            _spawnObject.transform.rotation = Quaternion.Euler(0f,0f,_lookAngle);
            Instantiate(_spawnObject);
        }  
    }
}
