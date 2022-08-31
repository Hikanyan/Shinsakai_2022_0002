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

    public abstract void Activate();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"){
            if (_sound)//����炷�ʒu�̓J�����̍��W
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }
        
    }
}
