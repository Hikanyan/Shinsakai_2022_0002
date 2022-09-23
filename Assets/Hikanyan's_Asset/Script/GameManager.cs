using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
/// <summary>
/// ゲームの進行状況の管理
/// </summary>

public class GameManager : MonoBehaviour
{
    private List<Transform> _retryPointList = new();

    private bool _gameStart;
    private bool _gamePaused;
    private bool _gameOver;
    private bool _gameClear;
    private bool _gameRespawn;

    public static GameManager instance;//Singleton

#if UNITY_EDITOR

#endif

    //[SerializeField] GameObject _a;




    private void Awake()//Singleton
    {
        if (instance == null)
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
        _gameClear = false;
    }

    /// <summary>
    /// ゲームがスタートした時に呼ばれる処理
    /// </summary>

    protected void GameStart()
    {
        _gameStart = true;
    }

    /// <summary>
    /// ゲームオーバーした時の処理
    /// </summary>
    protected void GameOver()
    {
        _gameOver = true;
        Debug.Log("GAMEOVER");
    }
    /// <summary>
    /// ゲームをポーズした時の処理
    /// </summary>
    protected void GamePaused()
    {
        _gamePaused = true;
    }

    /// <summary>
    /// ゲームをクリアした時の処理
    /// </summary>
    protected virtual void  GameClear()
    {
        _gameClear = true;

    }

    protected void Respawn(Collision other)
    {
        _gameRespawn = true;
        
        //座標を戻す
        this.gameObject.transform.position = _retryPointList.Last().position;//ここ

    }

    protected void Checkpoint(Collider other)
    {
        //リトライエリアをリストに追加
        if (other.gameObject.layer == LayerMask.NameToLayer("RetryPoint"))
        {
            _retryPointList.Add(other.gameObject.transform);
        }
    }
}
