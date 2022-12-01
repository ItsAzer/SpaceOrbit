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
        SceneManager.LoadScene(index);
        yield return null;
    }
}
