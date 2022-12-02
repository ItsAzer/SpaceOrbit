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

    void Update()
    {
        if(FindObjectOfType<GameManager>()._gameOver)
        {
            StopAllCoroutines();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color -= new Color(0f,0f,0f,0.003f);
            transform.localScale = new Vector3(transform.localScale.x + 0.0005f,transform.localScale.y + 0.0005f)
            *Time.timeScale;
        }
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
