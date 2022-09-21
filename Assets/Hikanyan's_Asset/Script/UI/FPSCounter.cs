using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSCounter : MonoBehaviour
{
    const float _fpsMeasurePeriod = .5f;
    private int _fpsAccumulator = 0;
    private float _fpsNextPeriod = 0;
    private int _currentFps;
    const string _display = "{0} FPS";
    private TextMeshProUGUI _guiText;

    void Start()
    {
        _fpsNextPeriod = Time.realtimeSinceStartup + _fpsMeasurePeriod;
        _guiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //1 •b‚ ‚½‚è‚Ì•½‹ÏƒtƒŒ[ƒ€”‚ð‘ª’è‚·‚é
        _fpsAccumulator++;
        if(Time.realtimeSinceStartup > _fpsNextPeriod)
        {
            _currentFps = (int)(_fpsAccumulator/_fpsMeasurePeriod);
            _fpsAccumulator = 0;
            _fpsNextPeriod += _fpsMeasurePeriod;
            _guiText.text = string.Format(_display, _currentFps);
        }
    }
}
