using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�C�e������������̊�{�I�ȏ���
/// ���ʉ���炷
/// �A�C�e��������
/// 
/// </summary>

public abstract class ItemBase : MonoBehaviour 
{
    [Tooltip("�A�C�e������������ɂȂ炷")]
    [SerializeField] AudioClip _sound = default;

    protected abstract void Activate();//protected�͎����̃N���X�Ɣh���N���X�ł̂ݎQ�Ƃł���

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (_sound)//����炷�ʒu�̓J�����̍��W
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }

    }
}
