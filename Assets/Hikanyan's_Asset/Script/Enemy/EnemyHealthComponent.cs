using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UniRx.Triggers;
public class EnemyHealthComponent : HealthComponent
{
    [SerializeField] TextMeshPro _hpTextUI;
    [SerializeField] HealthComponent healthComponent;

    protected override void Activate()
    {

    }
    private void Start()
    {

        _hpTextUI.text = $"{Life}";
        healthComponent
            .ObserveEveryValueChanged(x => x.Life)
            .Subscribe(_ => _hpTextUI.text = $"{Life}");
    }
}
