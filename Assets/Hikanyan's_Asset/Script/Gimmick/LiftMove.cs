using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LiftMove : MonoBehaviour
{
    
    [SerializeField] Transform _transform;
    [SerializeField] float _delay;
    [SerializeField] float _position;
    [SerializeField] float _second;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Sequence()
            .SetDelay(_delay)
            .Append(_transform.transform.DOMoveX(_position, _second).SetRelative())
            .Append(_transform.transform.DOMoveY(_position, _second).SetRelative())
            .Append(_transform.transform.DOMoveX(-_position, _second).SetRelative())
            .Append(_transform.transform.DOMoveY(-_position, _second).SetRelative())
            .SetLoops(-1)
            .Play();
    }
}
