using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e������������̊�{�I�ȏ���
/// ���ʉ���炷
/// �A�C�e��������
/// 
/// </summary>

public abstract class ItemBase
{
    [Tooltip("�A�C�e������������ɂȂ炷")]
    [SerializeField] AudioClip _sound = default;

    public abstract void Activate();
}
