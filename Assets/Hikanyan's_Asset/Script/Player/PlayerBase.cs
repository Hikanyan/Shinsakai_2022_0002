using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>プレイヤーを動かす為のコンポーネント</summary>

public abstract class PlayerBase: MonoBehaviour
{

    [Tooltip("プレイヤーの状態を表す変数")]

    /// <summary>プレイヤーの状態を表す変数</summary>
    [SerializeField] PlayerState _state;

    /// <summary>歩く加速度 </summary>
    [SerializeField] float _acceleration;

    /// <summary>歩く速さ</summary>
    [SerializeField] float _walkSpeed;

    /// <summary>慣性</summary>
    [SerializeField] float _brake = 0.5f;

    /// <summary>ジャンプ力</summary>
    [SerializeField] float _jumpForce;

    /// <summary>ジャンプした回数</summary>
    [SerializeField] int _jumpCount;

    /// <summary>ジャンプ回数の制限</summary>
    [SerializeField] float _jumpLimit;

    /// <summary>地面についているか</summary>
    [SerializeField] bool _onGround;

    /// <summary>カメラのスピード</summary>
    [SerializeField] float _cameraSpeed;

    /// <summary>ゴールしたか </summary>
    [SerializeField] bool _goalOn;

    /// <summary>ゲームオーバーしたか </summary>
    [SerializeField] bool _gameOverOn;

    /// <summary>リジットボディ</summary>
    private Rigidbody _rb;

    /// <summary>リジットボディのベクトル </summary>
    private Vector3 _rbVelo;

    /// <summary>前進入力の入力値を入れる変数</summary>
    float _horizontal;

    /// <summary>左右入力の入力値を入れる変数</summary>
    float _vertical;

    /// <summary>ジャンプの入力値を入れる変数</summary>
    float _Jump;


    protected abstract void Activate();

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _goalOn = false;
        _gameOverOn = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (_goalOn == false && _gameOverOn == false)
        {
            Move();
        }

    }

    protected virtual void CameraMove()
    {
        //カメラの向き
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        //プレイヤーの進行方向
        Vector3 moveForward = cameraForward * _vertical + transform.right * _horizontal;

        //カメラの向いてる方にプレイヤーを動かす
        _rb.velocity = new Vector3(moveForward.x * _walkSpeed, _rb.velocity.y, moveForward.z * _walkSpeed);

    }

    protected virtual void Move()
    {
        _rbVelo = Vector3.zero;
         _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _Jump = 0;
        if (_onGround == true)
        {
            _Jump = Input.GetAxis("Jump");
        }
        _rbVelo = _rb.velocity;
        _rb.AddForce((_horizontal * _walkSpeed - _rbVelo.x * _brake) * Time.deltaTime, (_Jump * _jumpForce) * Time.deltaTime, (_vertical * _walkSpeed - _rbVelo.x * _brake) * Time.deltaTime, ForceMode.Impulse);
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// 地面に触ってる時の判定
        {
            _onGround = true;
            Debug.Log(_onGround);
        }
    }


    protected void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// 地面から離れた時の判定
        {
            _onGround = false;
            Debug.Log(_onGround);
        }
    }
    
    /// <summary>プレイヤーの状態を列挙型で定義する</summary>
    enum PlayerState
    {
        idle,
        run,
        sideWalk,
        aim,
        jump,
    }
}
