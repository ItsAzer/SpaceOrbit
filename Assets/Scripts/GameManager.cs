using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if(FindObjectOfType<ScorePoint>() == null) 
        {
            GameOver(0);
        }

    }
    private float _gameOverDelay;
    public void GameOver(int index)
    {
        StartCoroutine(GameIsOver(index));
    }

    IEnumerator GameIsOver(int index)
    {
        while(_gameOverDelay <= 1f)
        {
            _gameOverDelay += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(index);
        _gameOverDelay = 0f;
        yield return null;
    }
}
