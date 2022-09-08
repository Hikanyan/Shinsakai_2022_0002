using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideOnOff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject emptyObject = new GameObject();
        emptyObject.transform.parent = this.transform;
        other.transform.parent = emptyObject.transform;
        emptyObject.name = "empty";
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        GameObject emptyObject = GameObject.Find("empty");
        Destroy(emptyObject);
    }
}
