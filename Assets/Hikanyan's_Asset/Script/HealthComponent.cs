using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�Aenemy�AObject�Ȃǂ�HP�𐧌䂷��
/// </summary>

public class HealthComponent
{
    /// <summary>
    /// �ő�HP
    /// </summary>
    public float _maxHp;
    /// <summary>
    /// ���݂�HP
    /// </summary>
    public float _life;

    /// <summary>
    /// �_���[�W���󂯂����̏���
    /// </summary>
    public void Damege(float damegePoint, float lifePoint)
    {
        lifePoint -= damegePoint;
    }

}
