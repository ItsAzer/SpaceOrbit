using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    [HideInInspector] public bool _touched;
    void Update()
    {
         
        if(_touched)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0f,0f,0f,0.003f);
            transform.localScale = new Vector3(transform.localScale.x + 0.0005f,transform.localScale.y + 0.0005f)
            *Time.timeScale;
            StartCoroutine(Destroyed());
        } 
    }

    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(2f);
         Destroy(gameObject);
    }
}
