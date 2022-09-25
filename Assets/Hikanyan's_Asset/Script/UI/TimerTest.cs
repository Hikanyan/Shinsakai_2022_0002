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
        // �X�y�[�X�L�[�����N���b�N�������ĊJ�n
        var waitUntilSpace = new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0));
        yield return waitUntilSpace;

        

        //// �Q�l���Ƃ��Čo�ߎ��Ԃ𑪒肷��
        //var stopwatch = new Stopwatch();
        //stopwatch.Start();

        // Connect
        _gameTimerManager.StartCountDown();

        // �J�E���g�_�E���̍w��
        _gameTimerManager.GameStartCountDownObservable
            .Subscribe(
                time =>
                {
                    _countText.text = $"{time}";
                    //Debug.Log($"GameStartCountDown: {time}, Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                },
                () =>
                {
                    //������
                    _countText.text = "";
                    GameManager.Instance.GameStart();
                    // �J�E���g�_�E�������������Ƃ�
                    // �Q�[���J�n
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
                    // �J�E���g�_�E�������������Ƃ�
                    // �Q�[���I��
                    //Debug.Log($"Time is up! Elapsed: {stopwatch.ElapsedMilliseconds * 0.001:F3}");
                    //stopwatch.Stop();
                    //GameManager.Instance.GameOver();
                })
            .AddTo(this);

        var gameClear = new WaitUntil(() => GameManager.Instance._gameStop);
        yield return gameClear;
        // �^�C���X�P�[����1.0�܂���0.0�ɐ؂�ւ��邱�Ƃ�
        // �J�E���g���ꎞ��~�A�܂��͍ĊJ����
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