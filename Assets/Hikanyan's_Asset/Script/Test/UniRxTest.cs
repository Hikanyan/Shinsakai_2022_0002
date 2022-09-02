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
            Debug.Log("1フレーム後に実行");
        }).AddTo(this);

        Debug.Log("すぐ実行");

        //100ms
        Observable.Timer(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        Debug.Log("100ミリセカンド後")).AddTo(this);
        //2フレーム待つ
        Observable.TimerFrame(2).Subscribe(_ =>
        Debug.Log("2フレーム後")).AddTo(this);
        //100msごとに呼ぶ
        Observable.Interval(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        Debug.Log("100ms経った")).AddTo(this);
    }
}
