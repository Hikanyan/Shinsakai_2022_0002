using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UnderLine : MonoBehaviour
{
    [SerializeField] PlayerOnTrigger _onTrigger;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onTrigger.DOTweenReset();
        }
    }
}
