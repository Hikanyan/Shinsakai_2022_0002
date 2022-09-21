using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] TextMeshPro _buttonText;
    [SerializeField] string _nextSceneName;
    [SerializeField] float _waitTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _buttonText.text = "ç∂ÉNÉäÉbÉNÇâüÇµÇƒ";
        }
        if (other.CompareTag("Player") || Input.GetMouseButtonDown(0))
        {
            _textMeshProUGUI.enabled = true;
        }
        else if (other.CompareTag("Player") || Input.GetMouseButtonUp(0))
        {
            _textMeshProUGUI.enabled = false;
            StartCoroutine("WaitTime");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _buttonText.text = "";
        }
    }
    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene(_nextSceneName);
    }
}
