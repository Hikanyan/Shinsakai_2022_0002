using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>プレイヤーを動かす為のコンポーネント</summary>

public abstract class PlayerBase : MonoBehaviour
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

    /// <summary>ジャンプ中にジャンプボタンを離した時の上昇減衰率</summary>
    [SerializeField] float _gravityDrag = .5f;

    /// <summary>地面についているか</summary>
    [SerializeField] bool _onGround;

    /// <summary>カメラのスピード</summary>
    [SerializeField] float _cameraSpeed;

    /// <summary>ゴールしたか </summary>
    [SerializeField] bool _goalOn;

    /// <summary>ゲームオーバーしたか </summary>
    [SerializeField] bool _gameOverOn;

    /// <summary>リジットボディ</summary>
     Rigidbody _rb;

    /// <summary>リジットボディのベクトル </summary>
     Vector3 _rbVelo;

    /// <summary>リスポーン </summary>
     Vector3 _initialPosition = default;

    /// <summary>前進入力の入力値を入れる変数</summary>
    float _horizontal;

    /// <summary>左右入力の入力値を入れる変数</summary>
    float _vertical;

    /// <summary>ジャンプの入力値を入れる変数</summary>
    float _Jump;

    /// <summary>持っているアイテムのリスト</summary>
    List<ItemBase> _itemList = new List<ItemBase>();

    protected abstract void Activate();

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _goalOn = false;
        _gameOverOn = false;
        _initialPosition = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (_goalOn == false && _gameOverOn == false)
        {
            Movement();
        }
    }

    protected virtual void CameraMove()
    {
        Debug.Log("ne");
        //カメラの向き
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        //プレイヤーの進行方向
        Vector3 moveForward = cameraForward * _vertical + transform.right * _horizontal;

        //カメラの向いてる方にプレイヤーを動かす
        _rb.velocity = new Vector3(moveForward.x * _walkSpeed, _rb.velocity.y, moveForward.z * _walkSpeed);

    }

    protected virtual void Movement()
    {
        _rbVelo = _rb.velocity;//この変数 velocity に速度を計算して、最後にRigidbody.velocityに戻す
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _Jump = 0;

        if(_horizontal != 0)
        {
            _rbVelo.x = (_horizontal * _walkSpeed - _rbVelo.x * _brake) * Time.deltaTime;
            Debug.Log(_rbVelo.x);
        }
        if(_vertical != 0)
        {
            _rbVelo.z = (_vertical * _walkSpeed - _rbVelo.x * _brake) * Time.deltaTime;
        }

        if (Input.GetButton("Jump")&&_onGround)
        {
            _rbVelo.y = (_Jump * _jumpForce) * Time.deltaTime;
        }
        else if(!Input.GetButton("Jump") && _rbVelo.y > 0)//ジャンプ中にジャンプボタンを離した時の上昇減衰
        {
            _rbVelo.y *= _gravityDrag * Time.deltaTime;
        }
        _rbVelo = _rb.velocity;
        _rb.AddForce(_rbVelo.x, _rbVelo.y, _rbVelo.z, ForceMode.Impulse);
    }

    /// <summary>アイテムをアイテムリストに追加する</summary>
    /// <param name="item"></param>
    void GetItem(ItemBase item)
    {
        _itemList.Add(item);
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// 地面に触ってる時の判定
        {
            _onGround = true;
            Debug.Log(_onGround);
        }
        if (other.gameObject.CompareTag("Kill"))// ﾀﾋ判定
        {
            this.transform.position = _initialPosition;
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
