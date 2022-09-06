using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float _bounce = 10.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 norm = other.contacts[0].normal;//[ ]はじめの当たった場所の法線ベクトルを取得します
            Vector3 vel = other.rigidbody.velocity.normalized;//衝突した速度ベクトルを「normalized 」で単位ベクトルにして一定の大きさのベクトルにします
            vel += new Vector3(-norm.x, 2, -norm.z * 2);//x,z方向に逆向きの法線ベクトルを 2 倍して足して反射方向のベクトルを得ます
            other.rigidbody.AddForce(vel * _bounce, ForceMode.Impulse);//vel方 向に速度をかけてはね返します
        }
    }
}
