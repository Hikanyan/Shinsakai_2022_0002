using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gool : GameManager
{
    [SerializeField] 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Debug.Log("�S�[��");
            GameClear();
        }
    }
}
