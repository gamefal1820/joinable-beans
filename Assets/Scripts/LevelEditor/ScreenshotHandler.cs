using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
	private static ScreenshotHandler instance;
	Camera myCamera;
	bool takeScreenshotAfterNextFrame;
	RenderTexture renderTexture;
	public static string SavePath;

	private void Awake()
	{
		instance = this;
		myCamera = gameObject.GetComponent<Camera>();
	}
	void OnPostRender()
	{
		if (takeScreenshotAfterNextFrame)
		{
			if (SavePath != null)
			{
				takeScreenshotAfterNextFrame = false;
				renderTexture = myCamera.targetTexture;

				Texture2D result = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
				Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
				result.ReadPixels(rect, 0, 0);

				byte[] ScreenshotData = result.EncodeToPNG();
				System.IO.File.WriteAllBytes(SavePath, ScreenshotData);
				RenderTexture.ReleaseTemporary(renderTexture);
				myCamera.targetTexture = null;
			}
			else
				Debug.LogError("Save path is null");
		}
	}
	void TakeScreenshot(int hieght, int width)
	{
		myCamera.targetTexture = RenderTexture.GetTemporary(width, hieght, 16);
		takeScreenshotAfterNextFrame = true;

	}
	public static void TakeShot(int hieght, int width)
	{
		instance.TakeScreenshot(hieght, width);
	}
}
