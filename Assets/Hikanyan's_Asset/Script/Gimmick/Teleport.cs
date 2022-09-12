using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[Serializable]
public class Teleport : MonoBehaviour
{

    [SerializeField, Tooltip("この位置にテレポートする")] GameObject _teleportPosition;//この位置にテレポートする
    [SerializeField, Tooltip("パーティクル")] ParticleSystem _particle;
    Vector3 _position;

    private void Start()
    {

        _position = _teleportPosition.transform.position;//テレポート先のオブジェクトの座標をポジションに入れる
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _particle.transform.position = other.transform.position;//プレイヤーが当たったところにパーティクル生成
            _particle.Play();
            StartCoroutine(Defeat(other));
        }
    }

    IEnumerator Defeat(Collider other)
    {

        other.gameObject.GetComponent<PlayerController>().enabled = false;//一時的にプレイヤーを操作できなくする
        //アニメーション再生
        yield return new WaitForSeconds(0.5f);//0.5秒待つ
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;//プレイヤーのメッシュレンダラを非表示
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;//自分のメッシュレンダラを非表示
        yield return new WaitForSeconds(1);//一秒待つ
        other.transform.position = _position;//プレイヤーをテレポート
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;//表示
        other.gameObject.GetComponent<PlayerController>().enabled = true;//動けるようにする

    }
}
