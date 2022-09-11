using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Teleport : MonoBehaviour
{

    [SerializeField, Tooltip("���̈ʒu�Ƀe���|�[�g����")] GameObject _teleportPosition;//���̈ʒu�Ƀe���|�[�g����
    [SerializeField, Tooltip("�p�[�e�B�N��")] ParticleSystem _particle;
    Vector3 _position;

    private void Start()
    {
        _position = _teleportPosition.transform.position;//�e���|�[�g��̃I�u�W�F�N�g�̍��W���|�W�V�����ɓ����
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _particle.transform.position = other.transform.position;//�v���C���[�����������Ƃ���Ƀp�[�e�B�N������
            _particle.Play();
            StartCoroutine(Defeat(other));
        }
    }

    IEnumerator Defeat(Collider other)
    {

        other.gameObject.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        other.transform.position = _position;//�v���C���[���e���|�[�g
        other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        other.gameObject.GetComponent<PlayerController>().enabled = true;

    }
}
