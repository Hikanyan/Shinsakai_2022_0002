using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>�v���C���[�𓮂����ׂ̃R���|�[�l���g</summary>

public abstract class PlayerBase : MonoBehaviour
{
    [Header("���C���̃J������ݒ肷��")]
    /// <summary>���C���̃J������ݒ肷��</summary>
    [SerializeField] GameObject _mainCamera;

    [SerializeField] GameObject _lookAtObj;

    [Tooltip("�v���C���[�̏�Ԃ�\���ϐ�")]

    /// <summary>�v���C���[�̏�Ԃ�\���ϐ�</summary>
    [SerializeField] PlayerState _state;

    /// <summary>��������</summary>
    [SerializeField] float _walkSpeed;

    /// <summary>�������Ƃ��̑���</summary>
    [SerializeField] float _spritSpeed = 15f;

    /// <summary>�W�����v�̍���</summary>
    [SerializeField] float _jumpForce = 5f;

    /// <summary>�W�����v������</summary>
    int _jumpCount;

    /// <summary>�W�����v�񐔂̐���</summary>
    [SerializeField] int _jumpLimit;

    /// <summary>�W�����v���ɃW�����v�{�^���𗣂������̏㏸������</summary>
    [SerializeField] float _gravityDrag = .5f;

    /// <summary>�S�[�������� </summary>
     bool _goalOn;

    /// <summary>�Q�[���I�[�o�[������ </summary>
    bool _gameOverOn;

    /// <summary>���Ⴊ�񂾂� </summary>
    bool _crouching = false;

    /// <summary>���W�b�g�{�f�B</summary>
    Rigidbody _rb;

    /// <summary>�����x�N�g�� </summary>
    Vector3 _dir = new Vector3(0, 0, 0);

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
        //�J�����̌����Ă���������猩�ăv���C���[�𓮂���
        //�w�肵���x�N�g���𐳖ʂƂ���
    }


    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    private void CharacterMove()
    {
        //���͏���
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //�����x�N�g�����擾
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
            //�_�b�V��
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
    void StartCrouch()//���Ⴊ��
    {
        _crouching = true;
        GetComponent<CapsuleCollider>().gameObject.transform.localScale = new(1, 0.5f, 1);
    }

    void EndCrouch()//���Ⴊ�ނ���߂�
    {
        _crouching = false;
        GetComponent<CapsuleCollider>().gameObject.transform.localScale = new(1, 1f, 1);
    }
    void Interact()
    {
        //�A�C�e�����E������
    }

    /*    protected virtual void Movement()
        {
            _rbVelo = _rb.velocity;//���̕ϐ� velocity �ɑ��x���v�Z���āA�Ō��Rigidbody.velocity�ɖ߂�
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
            else if (!Input.GetButton("Jump") && _rbVelo.y > 0)//�W�����v���ɃW�����v�{�^���𗣂������̏㏸����
            {
                _rbVelo.y *= _gravityDrag;
            }
            _rbVelo = _rb.velocity;
        }*/

    /// <summary>�A�C�e�����A�C�e�����X�g�ɒǉ�����</summary>
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

        if (other.gameObject.CompareTag("Kill"))// �˔���
        {
            this.transform.position = _initialPosition;
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

    IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerBase>().enabled = false;//PlayerBaseScript������
        {
            yield return new WaitForSeconds(1.0f);//��b�҂�
        }
        this.gameObject.GetComponent<PlayerBase>().enabled = true;//PlayerBaseScript�𕜊�
    }
}
