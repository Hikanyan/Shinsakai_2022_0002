using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class GameTimerManager : MonoBehaviour
{
    private IConnectableObservable<int> gameStartCountDownObservable;

    private IConnectableObservable<int> inPlayCountDownObservable;

    // �����J�n�O�̃J�E���g�_�E���iObservable�j
    public IObservable<int> GameStartCountDownObservable => gameStartCountDownObservable.AsObservable();

    // �������̃J�E���g�_�E���iObservable�j
    public IObservable<int> InPlayCountDownObservable => inPlayCountDownObservable.AsObservable();

    // �J�E���g�_�E���b��
    [SerializeField]  int CountDownTime  = 2;

    // �v���C�b��
    [SerializeField]  int PlayTime  = 60;

    private void Awake()
    {
        // �����O�̃J�E���g�_�E���^�C�}
        // CountDownTime�b�^�C�}�̃X�g���[����Publish��Hot�ϊ��i�܂�Connect�͂��Ȃ��j
        gameStartCountDownObservable = CreateCountDownObservable(CountDownTime).Publish();

        // �������̃^�C�}
        // PlayTime�b�^�C�}�̃X�g���[����Publish��Hot�ϊ��i�܂�Connect�͂��Ȃ��j
        inPlayCountDownObservable = CreateCountDownObservable(PlayTime).Publish();

        // 3�b�^�C�}��OnComplete��60�b�^�C�}��Connect����i60�b�^�C�}�̋N���j
        // �����炭���������R���v���[�g���̃R�[���o�b�N����
        gameStartCountDownObservable.Subscribe(_ => {; }, () => inPlayCountDownObservable.Connect());
    }

    // CountTime�����J�E���g�_�E������X�g���[��
    private IObservable<int> CreateCountDownObservable(int countTime)
    {
        return Observable.FromCoroutine<int>(observer => CountDownCoroutine(observer, countTime));
    }

    private float timeScale = 1.0f;

    // ���Ԍo�ߑ��x�̔{��
    public float TimeScale
    {
        get => timeScale;
        set => timeScale = Mathf.Max(value, 0.0f);
    }

    private IEnumerator CountDownCoroutine(IObserver<int> observer, int countTime, float interval = 1.0f)
    {
        var phase = interval;
        while (true)
        {
            yield return null;

            // �o�ߎ��Ԃ�ώZ���Ă���
            // ���̂Ƃ��A�o�ߎ��ԂɃ^�C���X�P�[�����悶�邱�Ƃ�
            // ���Ԍo�߂̑������R���g���[������
            phase += Time.deltaTime * timeScale;

            // phase��interval�𒴂��邽�тɒl�𔭍s����
            if (phase >= interval)
            {
                var invocationCount = (int)(phase / interval);
                phase %= interval;
                for (var i = 0; i < invocationCount; i++)
                {
                    if (countTime > 0)
                    {
                        observer.OnNext(countTime);
                    }
                    else
                    {
                        observer.OnCompleted();
                        yield break;
                    }

                    countTime--;
                }
            }
        }
    }

    // �J�E���g�_�E�����J�n
    public void StartCountDown()
    {
        // �Q�[���J�n�O�̃J�E���g�_�E���̃^�C�}�N��
        gameStartCountDownObservable.Connect();
    }
}