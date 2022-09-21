using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] GameObject _Weapon;
    [SerializeField] AudioSource _AudioSource;
    Rigidbody _rb;
    protected abstract void Activate();
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    protected virtual void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
