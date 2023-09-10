using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	static CheckpointManager instance;
	public Vector3 LastCheckpoint;

	private void Awake()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "MainMenu")
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(instance);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
	private void Update()
	{
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
			Destroy(gameObject);
	}

}
