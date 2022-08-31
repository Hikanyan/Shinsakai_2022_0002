using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̐i�s�󋵂̊Ǘ�
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
    private void Start()//������
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
