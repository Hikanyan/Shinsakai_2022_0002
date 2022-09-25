using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField] float _speed = 2;
    [SerializeField] float _theta = 45;
    [SerializeField] float _delay = 0.2f;
    private void Awake()
    {
        transform.DOLocalRotate(new Vector3(0, 0, _theta), _speed)
            .SetDelay(_delay)
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
