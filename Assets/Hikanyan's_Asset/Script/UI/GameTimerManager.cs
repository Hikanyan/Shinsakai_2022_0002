using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UniRx;
using System;
/// <summary>
/// カウントダウンするコンポーネント
/// </summary>
public class GameTimerManager : MonoBehaviour
{
    /// <summary>
    /// カウントダウンストリーム
    /// このObservableを各クラスがSubscribeする
    /// </summary>
    public IObservable<int> CountDownObservable
    {
        get
        {
            return _countDownObservable.AsObservable();
        }
    }

    private IConnectableObservable<int> _countDownObservable;

    void Awake()
    {
        //60秒カウントのストリームを作成
        //PublishでHot変換
        _countDownObservable = CreateCountDownObservable(60).Publish();
    }

    void Start()
    {
        //Start時にカウント開始
        _countDownObservable.Connect();
    }

    /// <summary>
    /// CountTimeだけカウントダウンするストリーム
    /// </summary>
    /// <param name="CountTime"></param>
    /// <returns></returns>
    private IObservable<int> CreateCountDownObservable(int CountTime)
    {
        return Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Select(x => (int)(CountTime - x))
            .TakeWhile(x => x > 0);
    }
}

