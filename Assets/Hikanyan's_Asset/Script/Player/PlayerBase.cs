using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>プレイヤーを動かす為のコンポーネント</summary>

public abstract class PlayerBase : MonoBehaviour
{
    [Header("メインのカメラを設定する")]
    /// <summary>メインのカメラを設定する</summary>
    [SerializeField] GameObject _mainCamera;

    [SerializeField] GameObject _lookAtObj;

    [Tooltip("プレイヤーの状態を表す変数")]

    /// <summary>プレイヤーの状態を表す変数</summary>
    [SerializeField] PlayerState _state;

    /// <summary>歩く速さ</summary>
    [SerializeField] float _walkSpeed;

    /// <summary>走ったときの速さ</summary>
    [SerializeField] float _spritSpeed = 15f;

    /// <summary>ジャンプの高さ</summary>
    [SerializeField] float _jumpForce = 5f;

    /// <summary>ジャンプした回数</summary>
    int _jumpCount;

    /// <summary>ジャンプ回数の制限</summary>
    [SerializeField] int _jumpLimit;

    /// <summary>ジャンプ中にジャンプボタンを離した時の上昇減衰率</summary>
    [SerializeField] float _gravityDrag = .5f;

    /// <summary>ゴールしたか </summary>
     bool _goalOn;

    /// <summary>ゲームオーバーしたか </summary>
    bool _gameOverOn;

    /// <summary>しゃがんだか </summary>
    bool _crouching = false;

    /// <summary>リジットボディ</summary>
    Rigidbody _rb;

    /// <summary>方向ベクトル </summary>
    Vector3 _dir = new Vector3(0, 0, 0);

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
    List<ItemBase> _itemList = new();

    Quaternion _characterRot;
    protected abstract void Activate();

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _goalOn = false;
        _gameOverOn = false;
        _initialPosition = this.transform.position;

        //_mainCamera = GameObject.Find("Player");
        //_lookAtObj = GameObject.Find("Player");
        _characterRot = transform.localRotation;

    }
    // Update is called once per frame
    void Update()
    {
        if (_goalOn == false && _gameOverOn == false)
        {
            //Movement();
            CharacterMove();
        }
    }

    private void FixedUpdate()
    {
        _dir = _mainCamera.transform.TransformDirection(_dir);

        _dir.y = 0;

        if (_dir != Vector3.zero)
        {

            Quaternion targetRotetion = Quaternion.LookRotation(_dir);
        }
        _rb.velocity = _dir.normalized * _walkSpeed + new Vector3(0, _rb.velocity.y, 0f);

        transform.LookAt(new Vector3(_lookAtObj.transform.position.x, transform.position.y, _lookAtObj.transform.position.z));
    }

    protected virtual void CameraMove()
    {
        //カメラの向いている方向から見てプレイヤーを動かす
        //指定したベクトルを正面として
    }


    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void CharacterMove()
    {
        //入力処理
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //方向ベクトルを取得
        _dir = new Vector3(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float distance = 0.2f;
            Vector3 rayPosition = transform.position + new Vector3(0.0f, _crouching ? -0.4f : -0.9f, 0.0f);
            Ray ray = new Ray(rayPosition, Vector3.down);
            bool isGround = Physics.Raycast(ray, distance);
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
            if (isGround)
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //ダッシュ
            _rb.AddForce(Vector3.forward * _spritSpeed);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCrouch();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            EndCrouch();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {

            Interact();
        }
    }
    void StartCrouch()//しゃがむ
    {
        _crouching = true;
        GetComponent<CapsuleCollider>().gameObject.transform.localScale = new(1, 0.5f, 1);
    }

    void EndCrouch()//しゃがむから戻る
    {
        _crouching = false;
        GetComponent<CapsuleCollider>().gameObject.transform.localScale = new(1, 1f, 1);
    }
    void Interact()
    {
        //アイテムを拾う処理
    }

    /*    protected virtual void Movement()
        {
            _rbVelo = _rb.velocity;//この変数 velocity に速度を計算して、最後にRigidbody.velocityに戻す
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _Jump = 0;

            if (_horizontal != 0)
            {
                _rbVelo.x = _horizontal * _walkSpeed;
                Debug.Log(_rbVelo.x);
            }
            if (_vertical != 0)
            {
                _rbVelo.z = _vertical * _walkSpeed;
            }

            if (Input.GetButton("Jump") && _onGround)
            {
                _rbVelo.y = _Jump * _jumpForce;
            }
            else if (!Input.GetButton("Jump") && _rbVelo.y > 0)//ジャンプ中にジャンプボタンを離した時の上昇減衰
            {
                _rbVelo.y *= _gravityDrag;
            }
            _rbVelo = _rb.velocity;
        }*/

    /// <summary>アイテムをアイテムリストに追加する</summary>
    /// <param name="item"></param>
    void GetItem(ItemBase item)
    {
        _itemList.Add(item);
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bounce"))
        {
            StartCoroutine("WaitKeyInput");
        }

        if (other.gameObject.CompareTag("Kill"))// ﾀﾋ判定
        {
            this.transform.position = _initialPosition;
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

    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerBase>().enabled = false;//PlayerBaseScriptを消す
        {
            yield return new WaitForSeconds(1.0f);//一秒待つ
        }
        this.gameObject.GetComponent<PlayerBase>().enabled = true;//PlayerBaseScriptを復活
    }
}
