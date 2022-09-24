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

    //���ʉ�
    [SerializeField] AudioClip _countDownTick;
    [SerializeField] AudioClip _countDownEnd;
    private AudioSource audioSource;

    [SerializeField] GameTimerManager _gameTimerManager;
    [SerializeField] TextMeshProUGUI _timer;

    void Start()
    {

        this.audioSource = GetComponent<AudioSource>();


        //�^�C�}�̎c�莞�Ԃ�`�悷��
        _gameTimerManager
            .CountDownObservable
            .Subscribe(time =>
            {
                //OnNext�Ŏ����̕`��
                _timer.text = string.Format("{0}", time);
            }, () =>
            {
                //OnComplete�ŕ���������
                _timer.text = string.Empty;
            });

        //�^�C�}��10�b�ȉ��ɂȂ����^�C�~���O�ŐF��Ԃ�����
        _gameTimerManager
            .CountDownObservable
            .First(timer => timer <= 10)
            .Subscribe(_ => _timer.color = Color.red);


        //�J�E���g��10�b�ȉ��ɂȂ�����SE��1�b���ɖ炷
        _gameTimerManager
            .CountDownObservable
            .Where(time => time <= 10)
            .Subscribe(_ => audioSource.PlayOneShot(_countDownTick));

        //�J�E���g�����������^�C�~���O��SE��炷
        _gameTimerManager
            .CountDownObservable
            .Subscribe(_ => {; }, () =>
            {
                audioSource.PlayOneShot(_countDownEnd);
                GameManager.instance.GameOver();
            });
    }
}