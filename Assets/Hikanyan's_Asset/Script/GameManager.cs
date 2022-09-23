using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
/// <summary>
/// �Q�[���̐i�s�󋵂̊Ǘ�
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
    private void Start()//������
    {
        _gameStart = false;
        _gamePaused = false;
        _gameOver = false;
        _gameClear = false;
    }

    /// <summary>
    /// �Q�[�����X�^�[�g�������ɌĂ΂�鏈��
    /// </summary>

    protected void GameStart()
    {
        _gameStart = true;
    }

    /// <summary>
    /// �Q�[���I�[�o�[�������̏���
    /// </summary>
    protected void GameOver()
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
    protected virtual void  GameClear()
    {
        _gameClear = true;

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
