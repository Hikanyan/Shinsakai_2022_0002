using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxTest : MonoBehaviour
{
    private void Start()
    {
       Observable.NextFrame().Subscribe(_ =>
        {
            Debug.Log("1�t���[����Ɏ��s");
        }).AddTo(this);

        Debug.Log("�������s");

        //100ms
        Observable.Timer(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        Debug.Log("100�~���Z�J���h��")).AddTo(this);
        //2�t���[���҂�
        Observable.TimerFrame(2).Subscribe(_ =>
        Debug.Log("2�t���[����")).AddTo(this);
        //100ms���ƂɌĂ�
        Observable.Interval(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        Debug.Log("100ms�o����")).AddTo(this);
    }
}
