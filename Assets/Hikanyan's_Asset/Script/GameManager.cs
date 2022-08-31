using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの進行状況の管理
/// </summary>

public class GameManager : MonoBehaviour
{
    private bool _gameStart;
    private bool _gamePaused;
    private bool _gameOver;


    public static GameManager instance;//Singleton

    private void Awake()//Singleton
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()//初期化
    {
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
    }

    void GameStart()
    {
        _gameStart =true;
    }
    void GameOver()
    {
        _gameOver =true;
    }
}
