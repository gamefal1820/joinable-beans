using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
	public CameraFollow _camera;
	public GameObject WinPan;
	public GameObject GamePan;

	private void Start()
	{
		_camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
		GamePan = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
		WinPan = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
			_camera.enabled = false;
			other.gameObject.SetActive(false);
			WinPan.SetActive(true);
			GamePan.SetActive(false);
			if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LevelPlayer")
			{
				string levelname = new System.IO.DirectoryInfo( GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().LevelPath).Name;
				WinPan.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = levelname + " Completed";
			}
		}
	}

}
