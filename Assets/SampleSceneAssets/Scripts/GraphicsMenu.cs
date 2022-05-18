using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.NVIDIA;

public class GraphicsMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    bool dlssSupport = false;
    HDAdditionalCameraData hdCamera;
    public void Awake()
    {
        GraphicsDevice nvidiaDevice = GraphicsDevice.CreateGraphicsDevice();
        dlssSupport = nvidiaDevice.IsFeatureAvailable(GraphicsDeviceFeature.DLSS);
        hdCamera = Camera.main.GetComponent<HDAdditionalCameraData>();
    }
    private void Start()
    {
        text.text = "DLSS OFF - " + hdCamera.antialiasing.ToString();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hdCamera != null && dlssSupport)
            {
                DLSSQuality quality = DLSSQuality.MaximumPerformance;
                Debug.Log("switching to DLSS '" + quality + "' preset.");
                text.text = "DLSS ON - " + quality;
                hdCamera.allowDeepLearningSuperSampling = true;
                hdCamera.deepLearningSuperSamplingQuality = (uint)quality;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hdCamera != null && dlssSupport)
            {
                DLSSQuality quality = DLSSQuality.Balanced;
                Debug.Log("switching to DLSS '" + quality + "' preset.");
                text.text = "DLSS ON - " + quality;
                hdCamera.allowDeepLearningSuperSampling = true;
                hdCamera.deepLearningSuperSamplingQuality = (uint)quality;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (hdCamera != null && dlssSupport)
            {
                DLSSQuality quality = DLSSQuality.MaximumQuality;
                Debug.Log("switching to DLSS '" + quality + "' preset.");
                text.text = "DLSS ON - " + quality;
                hdCamera.allowDeepLearningSuperSampling = true;
                hdCamera.deepLearningSuperSamplingQuality = (uint)quality;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (hdCamera != null)
            {
                Debug.Log("switching DLSS off.");
                text.text = "DLSS OFF - " + hdCamera.antialiasing.ToString();
                hdCamera.allowDeepLearningSuperSampling = false;
            }
        }

    }
}
