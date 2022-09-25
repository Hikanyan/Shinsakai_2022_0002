using System.Collections;
using System.Diagnostics;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class TimerTest : MonoBehaviour
{
    [SerializeField] GameTimerManager _gameTimerManager;
    [SerializeField] TextMeshProUGUI _countText;
    bool isCounting = true;


    private IEnumerator Start()
    {
        // スペースキーか左クリックを押して開始
        var waitUntilSpace = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0));
        yield return waitUntilSpace;

        

        //// 参考情報として経過時間を測定する
        //var stopwatch = new Stopwatch();
        //stopwatch.Start();

        // Connect
        _gameTimerManager.StartCountDown();

        // カウントダウンの購読
        _gameTimerManager.GameStartCountDownObservable
            .Subscribe(
                time =>
                {
                    _countText.text = $"{time}";
                    //Debug.Log($"GameStartCountDown: {time}, Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                },
                () =>
                {
                    //動ける
                    _countText.text = "";
                    GameManager.Instance.GameStart();
                    // カウントダウンが完了したとき
                    // ゲーム開始
                    //Debug.Log($"Start game! Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                })
            .AddTo(this);

        _gameTimerManager.InPlayCountDownObservable
            .Subscribe(
                time =>
                {
                    //Debug.Log($"InPlayCountDown: {time}, Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                },
                () =>
                {
                    // カウントダウンが完了したとき
                    // ゲーム終了
                    //Debug.Log($"Time is up! Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                    //stopwatch.Stop();
                    //GameManager.Instance.GameOver();
                })
            .AddTo(this);

        var gameClear = new WaitUntil(() => GameManager.Instance._gameStop);
        yield return gameClear;
        // タイムスケールを1.0または0.0に切り替えることで
        // カウントを一時停止、または再開する
        while (true)
        {
            yield return null;
            yield return gameClear;

            GameManager.Instance._gameStop = false;

            isCounting = !isCounting;
            if (isCounting)
            {
                _gameTimerManager.TimeScale = 1.0f;
                //stopwatch.Start();
                //Debug.Log($"Resumed. Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
            }
            else
            {
                _gameTimerManager.TimeScale = 0.0f;
                //stopwatch.Stop();
                //Debug.Log($"Paused. Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
            }

        }
    }
}