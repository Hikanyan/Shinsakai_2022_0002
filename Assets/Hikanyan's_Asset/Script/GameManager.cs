using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using UniRx;
/// <summary>
/// �Q�[���̐i�s�󋵂̊Ǘ�
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
    private void Start()//������
    {
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
        _gameClear = false;

        _goolTextImage.enabled = false;
    }

    /// <summary>
    /// �Q�[�����X�^�[�g�������ɌĂ΂�鏈��
    /// </summary>

    public void GameStart()
    {
        _gameStart = true;
    }

    /// <summary>
    /// �Q�[���I�[�o�[�������̏���
    /// </summary>
    public void GameOver()
    {
        _gameOver = true;
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
