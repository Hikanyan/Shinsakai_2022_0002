using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : GameManager
{
    private float _life;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Kill")
        {
            _life--;
        }
    }
}
