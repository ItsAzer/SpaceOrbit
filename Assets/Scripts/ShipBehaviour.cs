using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject _center; 
    private float _lookAngle;
    [SerializeField] private float _frequency = 1f, _amplitude = 1f;
 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float x = Mathf.Cos(Time.time * _frequency) * _amplitude;
        float y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        float z = transform.position.z;
        transform.position = new Vector3(x,y,z);
        
        Vector3 v = (-_center.transform.position + transform.position).normalized;
        _lookAngle = 90 + Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,_lookAngle);
        
    }

}
