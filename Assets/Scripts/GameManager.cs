using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _score;
    [HideInInspector] public bool _gameOver = false;
    void Update()
    {
        if(int.Parse(_score.text)== FindObjectOfType<ScorePointSpawner>()._numberOfPoints * 
        FindObjectOfType<Score>()._gameNum) 
        {
            FindObjectOfType<Score>()._gameNum++;
            _gameOver = true;
            GameOver(2);
            FindObjectOfType<BulletShooter>().enabled = false;
        }

    }
    private float _gameOverDelay;
    public void GameOver(int index)
    {
        StartCoroutine(GameIsOver(index));
    }

    IEnumerator GameIsOver(int index)
    {
        yield return new WaitForSeconds(index);
        _gameOver = false;
        SceneManager.LoadScene(0);
        yield return null;
        
    }
}
