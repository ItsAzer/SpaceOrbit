using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject _center; 
    private float _lookAngle, _direction = 1f;
    public float _frequency = 1f, _amplitude = 1f;
    private bool normalized, _gameOver = false;
    private float _time =0f;
    private BulletShooter _bs;
 
    void Start()
    {
        _bs = FindObjectOfType<BulletShooter>();
        _rb = GetComponent<Rigidbody2D>();
        _time = 1.57f/_frequency;
    }   
    void Update()
    {
        if(_gameOver)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0f,0f,0f,0.003f);
            transform.localScale = new Vector3(transform.localScale.x + 0.0005f,transform.localScale.y + 0.0005f)
            *Time.timeScale;
            StartCoroutine(Destroyed());
        }

        float x, y, z;
        x =  Mathf.Cos(_time* _frequency) * _amplitude;
        y = Mathf.Sin(_time* _frequency) * _amplitude;
        z = transform.position.z;
        if(!_gameOver)
        transform.position = new Vector3(x, y,z);
        if(Input.GetKeyDown(KeyCode.Mouse0)) _direction = -_direction;

        Vector3 v = (-_center.transform.position + transform.position).normalized;
        _lookAngle = 90 + Mathf.Atan2(v.y,v.x) * Mathf.Rad2Deg;
        

        if(_direction > 0)
        {
            _bs.x =  Mathf.Cos((_time + 2.45f/_bs._bulletSpeed)* _frequency) * _amplitude;
            _bs.y = Mathf.Sin((_time + 2.45f/_bs._bulletSpeed) * _frequency) * _amplitude;
            _time+= Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f,0f,_lookAngle);
            
        }
        else 
        {
            _bs.x =  Mathf.Cos((_time - 2.45f/_bs._bulletSpeed) * _frequency) * _amplitude;
            _bs.y = Mathf.Sin((_time - 2.45f/_bs._bulletSpeed) * _frequency) * _amplitude;
             _time -= Time.deltaTime;
             transform.rotation = Quaternion.Euler(0f,0f,_lookAngle-180);
        }
       
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Score Point")
        {
            col.GetComponent<ScorePoint>()._touched = true;
            FindObjectOfType<Score>()._score++;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        } 
        else
        {
            _gameOver = true;
            GetComponent<BoxCollider2D>().enabled = false;
            FindObjectOfType<Score>()._gameNum = 1;
            FindObjectOfType<Score>()._score = 0;
            
            GameObject.FindObjectOfType<GameManager>().GameOver(1);
        } 
    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(1f);
         Destroy(gameObject);
    }

}
