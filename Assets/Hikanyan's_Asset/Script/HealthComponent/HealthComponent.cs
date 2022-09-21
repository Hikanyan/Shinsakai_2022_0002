using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


/// <summary>
/// Player�Aenemy�AObject�Ȃǂ�HP�𐧌䂷��
/// </summary>

public abstract class HealthComponent : GameManager
{
    /// <summary>
    /// �ő�HP
    /// </summary>
    [SerializeField] protected float _maxHp;
    /// <summary>
    /// ���݂�HP
    /// </summary>
    [SerializeField] protected float _life;
    /// <summary>
    /// ���G���̔���
    /// </summary>
    [SerializeField] protected bool _damageState;
    /// <summary>
    /// �p���n
    /// </summary>
    [SerializeField] protected float _debuffTimer;
    /// <summary>�A�C�e������������ɖ���ʉ�</summary>
    [SerializeField] AudioClip _sound = default;
    public void Awake()
    {
        _life = _maxHp;
    }

    protected abstract void Activate(); 
    /// <summary>
    /// �_���[�W���󂯂����̏���
    /// </summary>
    /// <param name="damegePoint">�_���[�W��</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Damage(float damegePoint)
    {
        if (_damageState)
        {
            return;
        }

        _life -= damegePoint;

        if (_life <= 0)
        {
            GameOver();
        }
    }
    /// <summary>
    /// �񕜃A�C�e�����g�p������
    /// </summary>
    /// <param name="heelPoint">�񕜗�</param>
    /// <param name="lifePoint">���̗̑�</param>
    public void Heel(float heelPoint)
    {
        if (_maxHp >= _life)
        {
            _life += heelPoint;
        }
        else
        {
            _life = _maxHp;
        }
    }

    /// <summary>
    /// �p���_���[�W�Ɖ񕜃X�s�[�h�̏���
    /// </summary>
    public void Continuous(float timer)
    {
        _debuffTimer += timer * Time.deltaTime;


    }

    /// <summary>
    /// �_���[�W���󂯂��u�Ԃ̖��G���Ԃ̃^�C�}�[
    /// </summary>
    public IEnumerator DamageTimer()
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
