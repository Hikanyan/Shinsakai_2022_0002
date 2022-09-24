using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gool : GameManager
{
    [SerializeField] Image _image;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))//
        {
            Debug.Log("ÉSÅ[Éã");
            _image.enabled = true;
            GameClear();
        }
    }
    private void Start()
    {
        _image.enabled = false;
    }
}
