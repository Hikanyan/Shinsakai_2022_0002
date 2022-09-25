using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotationAnimation : MonoBehaviour
{
    [SerializeField] float _thetaX;
    [SerializeField] float _thetaY;
    [SerializeField] float _thetaZ;
    [SerializeField] float _time;
    private void Start()
    {
        transform.DOLocalRotate(new Vector3(_thetaX, _thetaY, _thetaZ), _time, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Incremental);
    }
}
