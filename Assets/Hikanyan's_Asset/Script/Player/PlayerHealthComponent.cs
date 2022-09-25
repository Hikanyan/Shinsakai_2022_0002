using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
public class PlayerHealthComponent : HealthComponent
{
    [SerializeField] TextMeshProUGUI _hpTextUI;
    [SerializeField] HealthComponent healthComponent;
    protected override void Activate()
    {
        
    }

    private void Start()
    {
        _hpTextUI.text = $"PlayerHP{Life}";
        healthComponent
            .ObserveEveryValueChanged(x => x.Life)
            .Subscribe(_ => _hpTextUI.text = $"PlayerHP{Life}");
    }
}
