using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>�v���C���[�𓮂����ׂ̃R���|�[�l���g</summary>

public abstract class PlayerBase: MonoBehaviour
{

    [Tooltip("�v���C���[�̏�Ԃ�\���ϐ�")]

    /// <summary>�v���C���[�̏�Ԃ�\���ϐ�</summary>
    [SerializeField] PlayerState _state;

    /// <summary>���������x </summary>
    [SerializeField] float _acceleration;

    /// <summary>��������</summary>
    [SerializeField] float _walkSpeed;

    /// <summary>����</summary>
    [SerializeField] float _brake = 0.5f;

    /// <summary>�W�����v��</summary>
    [SerializeField] float _jumpForce;

    /// <summary>�W�����v������</summary>
    [SerializeField] int _jumpCount;

    /// <summary>�W�����v�񐔂̐���</summary>
    [SerializeField] float _jumpLimit;

    /// <summary>�n�ʂɂ��Ă��邩</summary>
    [SerializeField] bool _onGround;

    /// <summary>�J�����̃X�s�[�h</summary>
    [SerializeField] float _cameraSpeed;

    /// <summary>�S�[�������� </summary>
    [SerializeField] bool _goalOn;

    /// <summary>�Q�[���I�[�o�[������ </summary>
    [SerializeField] bool _gameOverOn;

    /// <summary>���W�b�g�{�f�B</summary>
    private Rigidbody _rb;

    /// <summary>���W�b�g�{�f�B�̃x�N�g�� </summary>
    private Vector3 _rbVelo;

    /// <summary>�O�i���͂̓��͒l������ϐ�</summary>
    float _horizontal;

    /// <summary>���E���͂̓��͒l������ϐ�</summary>
    float _vertical;

    /// <summary>�W�����v�̓��͒l������ϐ�</summary>
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
        //�J�����̌���
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        //�v���C���[�̐i�s����
        Vector3 moveForward = cameraForward * _vertical + transform.right * _horizontal;

        //�J�����̌����Ă���Ƀv���C���[�𓮂���
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
        if (other.gameObject.CompareTag("Ground"))// �n�ʂɐG���Ă鎞�̔���
        {
            _onGround = true;
            Debug.Log(_onGround);
        }
    }


    protected void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// �n�ʂ��痣�ꂽ���̔���
        {
            _onGround = false;
            Debug.Log(_onGround);
        }
    }
    
    /// <summary>�v���C���[�̏�Ԃ�񋓌^�Œ�`����</summary>
    enum PlayerState
    {
        idle,
        run,
        sideWalk,
        aim,
        jump,
    }
}
