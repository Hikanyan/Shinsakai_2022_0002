using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class PlayerOnTrigger : MonoBehaviour
{
    [SerializeField] Transform _transformPos;
    [SerializeField] float _time;
    Vector3 _position;

    private void Start()
    {
        _position = _transformPos.transform.position;

        transform.DOLocalMove(_position, _time)
                .SetRelative()
                .SetLoops(-1,LoopType.Yoyo);
        transform.DOPause();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOPlay();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOPause();
        }
    }
}
