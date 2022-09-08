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
            Vector3 norm = other.contacts[0].normal;//[ ]�͂��߂̓��������ꏊ�̖@���x�N�g�����擾���܂�
            Vector3 vel = other.rigidbody.velocity.normalized;//�Փ˂������x�x�N�g�����unormalized �v�ŒP�ʃx�N�g���ɂ��Ĉ��̑傫���̃x�N�g���ɂ��܂�
            vel += new Vector3(-norm.x, 2, -norm.z * 2);//x,z�����ɋt�����̖@���x�N�g���� 2 �{���đ����Ĕ��˕����̃x�N�g���𓾂܂�
            other.rigidbody.AddForce(vel * _bounce, ForceMode.Impulse);//vel�� ���ɑ��x�������Ă͂˕Ԃ��܂�
        }
    }
}
