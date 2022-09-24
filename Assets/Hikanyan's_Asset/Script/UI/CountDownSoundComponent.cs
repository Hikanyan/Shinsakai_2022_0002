using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UniRx;
using System;


[RequireComponent(typeof(AudioSource))]

public class CountDownSoundComponent : MonoBehaviour
{

    //効果音
    [SerializeField] AudioClip _countDownTick;
    [SerializeField] AudioClip _countDownEnd;
    private AudioSource audioSource;

    [SerializeField] GameTimerManager _gameTimerManager;
    [SerializeField] TextMeshProUGUI _timer;

    void Start()
    {

        this.audioSource = GetComponent<AudioSource>();


        //タイマの残り時間を描画する
        _gameTimerManager
            .CountDownObservable
            .Subscribe(time =>
            {
                //OnNextで時刻の描画
                _timer.text = string.Format("{0}", time);
            }, () =>
            {
                //OnCompleteで文字を消す
                _timer.text = string.Empty;
            });

        //タイマが10秒以下になったタイミングで色を赤くする
        _gameTimerManager
            .CountDownObservable
            .First(timer => timer <= 10)
            .Subscribe(_ => _timer.color = Color.red);


        //カウントが10秒以下になったらSEを1秒毎に鳴らす
        _gameTimerManager
            .CountDownObservable
            .Where(time => time <= 10)
            .Subscribe(_ => audioSource.PlayOneShot(_countDownTick));

        //カウントが完了したタイミングでSEを鳴らす
        _gameTimerManager
            .CountDownObservable
            .Subscribe(_ => {; }, () =>
            {
                audioSource.PlayOneShot(_countDownEnd);
                GameManager.instance.GameOver();
            });
    }
}