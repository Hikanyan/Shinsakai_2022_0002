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

		systemInfo.Add("ユニークID", SystemInfo.deviceUniqueIdentifier);
		systemInfo.Add("OS情報", SystemInfo.operatingSystem);
		systemInfo.Add("CPU情報", SystemInfo.processorType);
		systemInfo.Add("メモリ情報", SystemInfo.systemMemorySize.ToString());
		
		systemInfo.Add("シェーダーの性能レベル", SystemInfo.graphicsShaderLevel.ToString());
#if UNITY_IPHONE
		systemInfo.Add("iPhoneモデル名", UnityEngine.iOS.Device.generation.ToString());
#endif
		systemInfo.Add("モデル名", SystemInfo.deviceModel);
		systemInfo.Add("端末名", SystemInfo.deviceName);
		systemInfo.Add("端末タイプ", SystemInfo.deviceType.ToString());
		
		systemInfo.Add("グラフィックデバイス名", SystemInfo.graphicsDeviceName.ToString());
		systemInfo.Add("グラフィックス API タイプ", SystemInfo.graphicsDeviceType.ToString());


		foreach (string key in systemInfo.Keys)
		{
			text.text += key + " = " + systemInfo[key] + "\n";
		}
	}
}
