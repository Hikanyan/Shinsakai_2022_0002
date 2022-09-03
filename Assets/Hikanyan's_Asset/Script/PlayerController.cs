using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameManager
{
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

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// ínñ Ç…êGÇ¡ÇƒÇÈéûÇÃîªíË
        {
            _isGround = true;

        }
        if (other.gameObject.CompareTag("Enemy"))//ìGÇ…Ç†ÇΩÇ¡ÇΩéûÇÃîªíË
        {
            
            Respawn(other);
        }
       /* if (other.gameObject.CompareTag("Attack"))//çUåÇÇ™ìñÇΩÇ¡ÇΩéûÇÃîªíË
        {
            FindObjectOfType<HealthComponent>().Damege(damegePoint:0);
        }*/
    }
    

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))// ínñ Ç©ÇÁó£ÇÍÇΩéûÇÃîªíË
        {
            _isGround = false;
        }
    }
}
