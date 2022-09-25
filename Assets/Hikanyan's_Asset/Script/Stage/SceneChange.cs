using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string _nextScene;
    [SerializeField] GameObject _mouseClickAnimation;
    private void Start()
    {
        _mouseClickAnimation.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&(Input.GetMouseButton(0)|| Input.GetMouseButton(1)))
        {
            Debug.Log("neko");
            SceneManager.LoadScene(_nextScene);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mouseClickAnimation.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mouseClickAnimation.SetActive(false);
        }
    }
}
