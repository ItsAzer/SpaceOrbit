using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [HideInInspector] public float x, y, x1, y1;
    public float _bulletSpeed = 3f;
    float _ac1 = 0f, _ac2 = 0f;
    private ShipBehaviour _sp;
    private float _rn1, _rn2;

    void Start()
    {
        _sp = FindObjectOfType<ShipBehaviour>();
        _rn1 = Random.Range(0.2f,0.5f);
        _rn2 = Random.Range(0.5f,1.3f);
    }
    void Update()
    {
        if(_ac1>_rn1)
        {
            _bullet.GetComponent<Bullet>()._v = new Vector3(_sp.transform.position.x
            ,_sp.transform.position.y).normalized * _bulletSpeed;
            Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _rn1 = Random.Range(0.2f,0.5f);
            _ac1 = 0f;
        }
        if(_ac2>_rn2)
        {
            _bullet.GetComponent<Bullet>()._v = new Vector3(x,y).normalized * _bulletSpeed;
            Instantiate(_bullet, this.transform.position, this.transform.rotation);
            _rn2 = Random.Range(0.5f,1.3f);
            _ac2 = 0f;
        }
        _ac1 += Time.deltaTime;
        _ac2 += Time.deltaTime;
    }
}
