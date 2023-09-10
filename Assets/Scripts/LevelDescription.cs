using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDescription : MonoBehaviour
{
	public static bool canTrain;
	static LevelDescription instance;
	private void Start()
	{
	//	DontDestroyOnLoad(this.gameObject);

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
			Destroy(gameObject);
	}
}
