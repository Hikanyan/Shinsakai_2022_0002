using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�Aenemy�AObject�Ȃǂ�HP�𐧌䂷��
/// </summary>

public class HealthComponent : MonoBehaviour 
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
    /// <param name="damegePoint">�_���[�W��</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Damege(float damegePoint, float lifePoint)
    {
        lifePoint -= damegePoint;
    }
    /// <summary>
    /// �񕜃A�C�e�����g�p������
    /// </summary>
    /// <param name="heelPoint">�񕜗�</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Heel(float heelPoint, float lifePoint)
    {
        lifePoint += heelPoint;
    }

}
