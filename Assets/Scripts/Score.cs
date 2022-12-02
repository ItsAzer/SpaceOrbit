using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score _instance;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
        }
        DontDestroyOnLoad(_instance);
    }
    [HideInInspector] public int _score = 0;
    [SerializeField] TextMeshProUGUI _scoreText;
    [HideInInspector] public int _gameNum = 1;

    void Update()
    {
        _scoreText.text = _score.ToString();
    }
}
