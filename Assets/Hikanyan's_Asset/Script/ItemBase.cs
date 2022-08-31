using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムを取った時の基本的な処理
/// 効果音を鳴らす
/// アイテムを消す
/// 
/// </summary>

public abstract class ItemBase
{
    [Tooltip("アイテムを取った時にならす")]
    [SerializeField] AudioClip _sound = default;

    public abstract void Activate();
}
