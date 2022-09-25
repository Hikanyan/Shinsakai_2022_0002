using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
/// <summary>
/// ゲームの進行状況の管理
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton
    private List<Transform> _retryPointList = new();

    public bool _gameStart;
    public bool _gamePaused;
    public bool _gameOver;
    public bool _gameClear;
    public bool _gameStop;
    public bool _gameRespawn;

    [SerializeField] Image _goolTextImage;

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
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
        _gameClear = false;

        _goolTextImage.enabled = false;
    }

    /// <summary>
    /// ゲームがスタートした時に呼ばれる処理
    /// </summary>

    public void GameStart()
    {
        _gameStart = true;
    }

    /// <summary>
    /// ゲームオーバーした時の処理
    /// </summary>
    public void GameOver()
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
    public void GameClear()
    {
        _gameClear = true;
        _gameStop = true;
        _goolTextImage.enabled = true;
        Debug.Log("クリア");
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
