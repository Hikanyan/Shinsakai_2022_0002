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

    public bool _damageState;

    /// <summary>
    /// �_���[�W���󂯂����̏���
    /// </summary>
    /// <param name="damegePoint">�_���[�W��</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Damege(float damegePoint)
    {
        if (_damageState)
        {
            return;
        }

        _life -= damegePoint;
    }
    /// <summary>
    /// �񕜃A�C�e�����g�p������
    /// </summary>
    /// <param name="heelPoint">�񕜗�</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Heel(float heelPoint)
    {
        if (_maxHp > _life)
        {
            _life += heelPoint;
        }
    }

    /// <summary>
    /// �p���_���[�W�Ɖ񕜃X�s�[�h�̏���
    /// </summary>
    public void Continuous()
    {

    }

    /// <summary>
    /// �_���[�W���󂯂��u�Ԃ̖��G���Ԃ̃^�C�}�[
    /// </summary>
    protected IEnumerator DamageTimer()
    {
        if (_damageState)//���Ƀ_���[�W��Ԃł���ΏI��
        {
            yield break;
        }

        _damageState = true;

        //���̊Ԃɖ��G���̏���������

        _damageState = false;
    }
}
