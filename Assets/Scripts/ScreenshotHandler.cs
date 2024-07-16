using UnityEngine;
using System.IO;

public class ScreenshotHandler : MonoBehaviour
{
    public string screenshotDirectory;

    void Start()
    {
        // ���û������·����ʹ��Ĭ��·��
        if (string.IsNullOrEmpty(screenshotDirectory))
        {
            screenshotDirectory = Path.Combine(Application.persistentDataPath, "Screenshots");
        }

        // ȷ��Ŀ¼����
        if (!Directory.Exists(screenshotDirectory))
        {
            Directory.CreateDirectory(screenshotDirectory);
        }
    }

    void Update()
    {
        // ���¼����ϵ� "K" ��ʱ��ȡ��Ļ��ͼ
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot()
    {
        // �����ļ�����·��
        string fileName = $"Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        string filePath = Path.Combine(screenshotDirectory, fileName);

        // ��ȡ��Ļ������ΪPNG�ļ�
        ScreenCapture.CaptureScreenshot(filePath);

        Debug.Log($"Screenshot saved to: {filePath}");
    }
}