using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムを取った時の基本的な処理
/// 効果音を鳴らす
/// アイテムを消す
/// 
/// </summary>

public abstract class ItemBase : MonoBehaviour 
{
    [Tooltip("アイテムを取った時にならす")]
    [SerializeField] AudioClip _sound = default;

    protected abstract void Activate();//protectedは自分のクラスと派生クラスでのみ参照できる

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (_sound)//音を鳴らす位置はカメラの座標
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }

    }
}
