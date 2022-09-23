using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gool : GameManager
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Debug.Log("ÉSÅ[Éã");
            GameClear();
        }
    }
}
