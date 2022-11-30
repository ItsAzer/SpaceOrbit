using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject _center; 
    private float _lookAngle, _direction = 1f;
    [SerializeField] private float _frequency = 1f, _amplitude = 1f;
    private bool normalized;
    private float _time =0f;
 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _time = 1.57f/_frequency;
    }   
    void Update()
    {
        
        float x, y, z;
        x =  Mathf.Cos(_time * _frequency ) * _amplitude;
        y = Mathf.Sin(_time * _frequency) * _amplitude;
        z = transform.position.z;
        transform.position = new Vector3(x, y,z);
        if(Input.GetKeyDown(KeyCode.Mouse0)) _direction = -_direction;

        Vector3 v = (-_center.transform.position + transform.position).normalized;
        _lookAngle = 90 + Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;
        

        if(_direction > 0)
        {
            _time+= Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f,0f,_lookAngle);
            
        }
        else 
        {
             _time -= Time.deltaTime;
             transform.rotation = Quaternion.Euler(0f,0f,_lookAngle-180);
        }
       
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Score Point") col.GetComponent<ScorePoint>()._touched = true;
        else GameObject.FindObjectOfType<GameManager>().GameOver(0);
    }

}
