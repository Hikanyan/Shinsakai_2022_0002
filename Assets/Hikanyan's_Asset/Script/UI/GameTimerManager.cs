using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class GameTimerManager : MonoBehaviour
{
    private IConnectableObservable<int> gameStartCountDownObservable;

    private IConnectableObservable<int> inPlayCountDownObservable;

    // 試合開始前のカウントダウン（Observable）
    public IObservable<int> GameStartCountDownObservable => gameStartCountDownObservable.AsObservable();

    // 試合中のカウントダウン（Observable）
    public IObservable<int> InPlayCountDownObservable => inPlayCountDownObservable.AsObservable();

    // カウントダウン秒数
    [SerializeField]  int CountDownTime  = 2;

    // プレイ秒数
    [SerializeField]  int PlayTime  = 60;

    private void Awake()
    {
        // 試合前のカウントダウンタイマ
        // CountDownTime秒タイマのストリームをPublishでHot変換（まだConnectはしない）
        gameStartCountDownObservable = CreateCountDownObservable(CountDownTime).Publish();

        // 試合中のタイマ
        // PlayTime秒タイマのストリームをPublishでHot変換（まだConnectはしない）
        inPlayCountDownObservable = CreateCountDownObservable(PlayTime).Publish();

        // 3秒タイマのOnCompleteで60秒タイマをConnectする（60秒タイマの起動）
        // おそらく第二引数がコンプリート時のコールバック処理
        gameStartCountDownObservable.Subscribe(_ => {; }, () => inPlayCountDownObservable.Connect());
    }

    // CountTimeだけカウントダウンするストリーム
    private IObservable<int> CreateCountDownObservable(int countTime)
    {
        return Observable.FromCoroutine<int>(observer => CountDownCoroutine(observer, countTime));
    }

    private float timeScale = 1.0f;

    // 時間経過速度の倍率
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

            // 経過時間を積算していく
            // このとき、経過時間にタイムスケールを乗じることで
            // 時間経過の速さをコントロールする
            phase += Time.deltaTime * timeScale;

            // phaseがintervalを超えるたびに値を発行する
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

    // カウントダウンを開始
    public void StartCountDown()
    {
        // ゲーム開始前のカウントダウンのタイマ起動
        gameStartCountDownObservable.Connect();
    }
}