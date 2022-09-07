using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>�v���C���[�𓮂����ׂ̃R���|�[�l���g</summary>

public abstract class PlayerBase : MonoBehaviour
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

    /// <summary>�W�����v���ɃW�����v�{�^���𗣂������̏㏸������</summary>
    [SerializeField] float _gravityDrag = .5f;

    /// <summary>�n�ʂɂ��Ă��邩</summary>
    [SerializeField] bool _onGround;

    /// <summary>�J�����̃X�s�[�h</summary>
    [SerializeField] float _cameraSpeed;

    /// <summary>�S�[�������� </summary>
    [SerializeField] bool _goalOn;

    /// <summary>�Q�[���I�[�o�[������ </summary>
    [SerializeField] bool _gameOverOn;

    /// <summary>���W�b�g�{�f�B</summary>
     Rigidbody _rb;

    /// <summary>���W�b�g�{�f�B�̃x�N�g�� </summary>
     Vector3 _rbVelo;

    /// <summary>���X�|�[�� </summary>
     Vector3 _initialPosition = default;

    /// <summary>�O�i���͂̓��͒l������ϐ�</summary>
    float _horizontal;

    /// <summary>���E���͂̓��͒l������ϐ�</summary>
    float _vertical;

    /// <summary>�W�����v�̓��͒l������ϐ�</summary>
    float _Jump;

    /// <summary>�����Ă���A�C�e���̃��X�g</summary>
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
        //�J�����̌���
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;

        //�v���C���[�̐i�s����
        Vector3 moveForward = cameraForward * _vertical + transform.right * _horizontal;

        //�J�����̌����Ă���Ƀv���C���[�𓮂���
        _rb.velocity = new Vector3(moveForward.x * _walkSpeed, _rb.velocity.y, moveForward.z * _walkSpeed);

    }

    protected virtual void Movement()
    {
        _rbVelo = _rb.velocity;//���̕ϐ� velocity �ɑ��x���v�Z���āA�Ō��Rigidbody.velocity�ɖ߂�
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
        else if(!Input.GetButton("Jump") && _rbVelo.y > 0)//�W�����v���ɃW�����v�{�^���𗣂������̏㏸����
        {
            _rbVelo.y *= _gravityDrag * Time.deltaTime;
        }
        _rbVelo = _rb.velocity;
        _rb.AddForce(_rbVelo.x, _rbVelo.y, _rbVelo.z, ForceMode.Impulse);
    }

    /// <summary>�A�C�e�����A�C�e�����X�g�ɒǉ�����</summary>
    /// <param name="item"></param>
    void GetItem(ItemBase item)
    {
        _itemList.Add(item);
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// �n�ʂɐG���Ă鎞�̔���
        {
            _onGround = true;
            Debug.Log(_onGround);
        }
        if (other.gameObject.CompareTag("Kill"))// �˔���
        {
            this.transform.position = _initialPosition;
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
