using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using System;

/// <summary>
/// ゲームの進行状況の管理
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton
    private List<Transform> _retryPointList = new();
    [Header("プレイヤーコントローラー")]
    [SerializeField] PlayerController _playerController;
    [Header("Start画像")]
    [SerializeField] Image _startImage;
    [Header("Gool画像")]
    [SerializeField] Image _goolTextImage;
    [Header("GameOver画像")]
    [SerializeField] Image _gameOverTextImage;
    [NonSerialized] public bool _gameStart;
    [NonSerialized] public bool _gamePaused;
    [NonSerialized] public bool _gameOver;
    [NonSerialized] public bool _gameClear;
    [NonSerialized] public bool _gameStop;
    [NonSerialized] public bool _gameRespawn;


#if UNITY_EDITOR

#endif

    private void Awake()//Singleton
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()//初期化
    {
        _playerController.gameObject.GetComponent<PlayerController>().enabled = false;//一時的にプレイヤーを操作できなくする
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
        _gameClear = false;

        _startImage.enabled = true;
        _gameOverTextImage.enabled = false;
        _goolTextImage.enabled = false;

    }

    /// <summary>
    /// ゲームがスタートした時に呼ばれる処理
    /// </summary>

    public void GameStart()
    {
        _gameStart = true;
        _startImage.enabled = false;
        _playerController.gameObject.GetComponent<PlayerController>().enabled = true;
    }

    /// <summary>
    /// ゲームオーバーした時の処理
    /// </summary>
    public void GameOver()
    {
        _gameOver = true;
        _gameOverTextImage.enabled = true;
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
    public void GameClear()
    {
        _gameClear = true;
        _gameStop = true;
        _goolTextImage.enabled = true;
        Debug.Log("クリア");
        _playerController.gameObject.GetComponent<PlayerController>().enabled = false;
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
