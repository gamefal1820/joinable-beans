using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLevelManage : MonoBehaviour
{
	public static CustomLevelManage instance;
	public string LevelPath;
	public string Author;
	public bool IsEdit;

	private void Awake()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LevelEditor")
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else if (instance != this)
				Destroy(gameObject);
		}
	}
}
