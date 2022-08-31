using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : GameManager
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Kill")
        {
            life--;
        }
    }
}
