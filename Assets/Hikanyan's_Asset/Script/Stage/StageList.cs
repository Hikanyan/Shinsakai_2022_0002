using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class StageList : MonoBehaviour
{
    [SerializeField] Transform _parentTransform;

    private void Awake()
    {

        foreach (Transform childTransfom in _parentTransform)
        {
            //DOTween.Sequence()
            //    .Append(transform.DOLocalRotate(new Vector3(0, 360f, 0), 6f, RotateMode.FastBeyond360)
            //    .SetEase(Ease.Linear))
            //    .Join(transform.DOMoveY(0.5f, 2f)
            //    .SetLoops(-1, LoopType.Yoyo)
            //    .Play()
            //    );

            DOTween.Sequence()
                .Append(childTransfom.transform.DOLocalRotate(new Vector3(0, 360f, 0), 6f).SetRelative())
                .Join(childTransfom.transform.DOMoveY(0.5f, 2f).SetRelative())
                .SetLoops(-1, LoopType.Yoyo)
                .Play();
        }
    }
}
