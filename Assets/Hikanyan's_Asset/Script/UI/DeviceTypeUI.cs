using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeviceTypeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
		text.text = "";
		Dictionary<string, string> systemInfo = new Dictionary<string, string>();

		systemInfo.Add("���j�[�NID", SystemInfo.deviceUniqueIdentifier);
		systemInfo.Add("OS���", SystemInfo.operatingSystem);
		systemInfo.Add("CPU���", SystemInfo.processorType);
		systemInfo.Add("���������", SystemInfo.systemMemorySize.ToString());
		
		systemInfo.Add("�V�F�[�_�[�̐��\���x��", SystemInfo.graphicsShaderLevel.ToString());
#if UNITY_IPHONE
		systemInfo.Add("iPhone���f����", UnityEngine.iOS.Device.generation.ToString());
#endif
		systemInfo.Add("���f����", SystemInfo.deviceModel);
		systemInfo.Add("�[����", SystemInfo.deviceName);
		systemInfo.Add("�[���^�C�v", SystemInfo.deviceType.ToString());
		
		systemInfo.Add("�O���t�B�b�N�f�o�C�X��", SystemInfo.graphicsDeviceName.ToString());
		systemInfo.Add("�O���t�B�b�N�X API �^�C�v", SystemInfo.graphicsDeviceType.ToString());


		foreach (string key in systemInfo.Keys)
		{
			text.text += key + " = " + systemInfo[key] + "\n";
		}
	}
}
