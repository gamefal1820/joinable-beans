using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
	float timeElapsed;
	bool firstActicate;
	public GameObject ButtonsParrent;

	void Start()
	{

	}
	void Update()
	{
		if (timeElapsed < 3)
		{//11.34
			transform.position = Vector3.Lerp(new Vector3(-4.48f, 8.5f, -4.94f), 
				new Vector3(-4.48f, 1.34f, -4.94f),Mathf.SmoothStep(0,1, timeElapsed / 3));
			timeElapsed += Time.deltaTime;
		}
		else if(!firstActicate)
		{
			transform.position = new Vector3(-4.48f, 1.34f, -4.94f);
			ButtonsParrent.SetActive(true);
			firstActicate = true;
		}

	}
}
