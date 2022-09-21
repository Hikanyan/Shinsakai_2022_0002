using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabelOnOff : MonoBehaviour
{
    [SerializeField] GameObject _label;
    bool _enabled;
    public void LabelOnOff()
    {
        if (_enabled == false)
        {
            _label.SetActive(true);
            _enabled = true;
        }
        else if (_enabled == true)
        {
            _label.SetActive(false);
            _enabled = false;
        }
        
    }
}
