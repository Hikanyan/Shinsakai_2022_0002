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

    public abstract void Activate();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"){
            if (_sound)//音を鳴らす位置はカメラの座標
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
        }
        
    }
}
