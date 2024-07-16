using UnityEngine;
using System.IO;

public class ScreenshotHandler : MonoBehaviour
{
    public string screenshotDirectory;

    void Start()
    {
        // 如果没有设置路径，使用默认路径
        if (string.IsNullOrEmpty(screenshotDirectory))
        {
            screenshotDirectory = Path.Combine(Application.persistentDataPath, "Screenshots");
        }

        // 确保目录存在
        if (!Directory.Exists(screenshotDirectory))
        {
            Directory.CreateDirectory(screenshotDirectory);
        }
    }

    void Update()
    {
        // 按下键盘上的 "K" 键时截取屏幕截图
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot()
    {
        // 定义文件名和路径
        string fileName = $"Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        string filePath = Path.Combine(screenshotDirectory, fileName);

        // 截取屏幕并保存为PNG文件
        ScreenCapture.CaptureScreenshot(filePath);

        Debug.Log($"Screenshot saved to: {filePath}");
    }
}