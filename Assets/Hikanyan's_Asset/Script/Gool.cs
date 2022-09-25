using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gool :MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameClear();
        }
    }
}
