using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UniRx;
using System;
/// <summary>
/// �J�E���g�_�E������R���|�[�l���g
/// </summary>
public class GameTimerManager : MonoBehaviour
{
    [SerializeField] int _timeLimit = 360;

    /// <summary>
    /// �J�E���g�_�E���X�g���[��
    /// ����Observable���e�N���X��Subscribe����
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
        //_timeLimit�b�J�E���g�̃X�g���[�����쐬
        //Publish��Hot�ϊ�
        _countDownObservable = CreateCountDownObservable(_timeLimit).Publish();
    }

    void Start()
    {
        //Start���ɃJ�E���g�J�n
        _countDownObservable.Connect();
    }

    /// <summary>
    /// CountTime�����J�E���g�_�E������X�g���[��
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

