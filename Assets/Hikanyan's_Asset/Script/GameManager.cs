using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
using System;

/// <summary>
/// �Q�[���̐i�s�󋵂̊Ǘ�
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton
    private List<Transform> _retryPointList = new();
    [Header("�v���C���[�R���g���[���[")]
    [SerializeField] PlayerController _playerController;
    [Header("Start�摜")]
    [SerializeField] Image _startImage;
    [Header("Gool�摜")]
    [SerializeField] Image _goolTextImage;
    [Header("GameOver�摜")]
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
    private void Start()//������
    {
        _playerController.gameObject.GetComponent<PlayerController>().enabled = false;//�ꎞ�I�Ƀv���C���[�𑀍�ł��Ȃ�����
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
        _gameClear = false;

        _startImage.enabled = true;
        _gameOverTextImage.enabled = false;
        _goolTextImage.enabled = false;

    }

    /// <summary>
    /// �Q�[�����X�^�[�g�������ɌĂ΂�鏈��
    /// </summary>

    public void GameStart()
    {
        _gameStart = true;
        _startImage.enabled = false;
        _playerController.gameObject.GetComponent<PlayerController>().enabled = true;
    }

    /// <summary>
    /// �Q�[���I�[�o�[�������̏���
    /// </summary>
    public void GameOver()
    {
        _gameOver = true;
        _gameOverTextImage.enabled = true;
        Debug.Log("GAMEOVER");
    }
    /// <summary>
    /// �Q�[�����|�[�Y�������̏���
    /// </summary>
    protected void GamePaused()
    {
        _gamePaused = true;
    }

    /// <summary>
    /// �Q�[�����N���A�������̏���
    /// </summary>
    public void GameClear()
    {
        _gameClear = true;
        _gameStop = true;
        _goolTextImage.enabled = true;
        Debug.Log("�N���A");
        _playerController.gameObject.GetComponent<PlayerController>().enabled = false;
    }

    protected void Respawn(Collision other)
    {
        _gameRespawn = true;

        //���W��߂�
        this.gameObject.transform.position = _retryPointList.Last().position;//����

    }

    protected void Checkpoint(Collider other)
    {
        //���g���C�G���A�����X�g�ɒǉ�
        if (other.gameObject.layer == LayerMask.NameToLayer("RetryPoint"))
        {
            _retryPointList.Add(other.gameObject.transform);
        }
    }
}
