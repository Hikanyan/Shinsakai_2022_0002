using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ‰ñ•œƒAƒCƒeƒ€‚ğæ‚Á‚½‚Ìˆ—
/// </summary>
public class Heel : ItemBase
{
    [SerializeField] float _heelPoint;
    [SerializeField] float _lifePoint;
    [SerializeField] ParticleSystem _particleSystem;

    protected override void Activate()
    {
        FindObjectOfType<HealthComponent>().Heel(heelPoint: _heelPoint);
    }
}
