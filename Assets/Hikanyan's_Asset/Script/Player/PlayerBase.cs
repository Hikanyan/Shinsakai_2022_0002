using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �v���C���[�𓮂����ׂ̃R���|�[�l���g
/// </summary>

public class PlayerBase : MonoBehaviour
{

    [Tooltip("�v���C���[�̏�Ԃ�\���ϐ�")]
    /// <summary>�v���C���[�̏�Ԃ�\���ϐ�</summary>
    [SerializeField]    _state
    [SerializeField] float _speed = 12.0f;
    [SerializeField] float _jumpSpeed = 1.0f;
    [SerializeField] float _brake = 0.5f;
    private bool _isGround = false;
    private Rigidbody _rb;
    private Vector3 _rbVelo;

    [SerializeField] bool _goalOn;
    [SerializeField] bool _gameOverOn;

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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        if (_isGround == true)
        {
            y = Input.GetAxis("Jump");
        }
        _rbVelo = _rb.velocity;
        _rb.AddForce((x * _speed - _rbVelo.x * _brake) * Time.deltaTime, (y * _jumpSpeed) * Time.deltaTime, (z * _speed - _rbVelo.x * _brake) * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// �n�ʂɐG���Ă鎞�̔���
        {
            _isGround = true;

        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// �n�ʂ��痣�ꂽ���̔���
        {
            _isGround = false;
        }
    }
}
