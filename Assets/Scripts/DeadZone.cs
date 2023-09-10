using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
	private bool isenabled;
	public CameraFollow _camera;
	public GameObject GamePanel;
	public GameObject WastedPanel;

	public GameObject Player;
	private void Start()
	{
		isenabled = true;
		Player = GameObject.Find("Main Bean");
		_camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
		GamePanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
		WastedPanel = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
	}

	void OnTriggerEnter(Collider collision)
	{
		if (isenabled)
		{
			if (collision.gameObject.tag == "Player")
			{
				collision.gameObject.SetActive(false);
				_camera.enabled = false;
				//if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android ||
				//EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
#if UNITY_ANDROID
				GamePanel.SetActive(false);
#endif
				WastedPanel.SetActive(true);

			}
			//else if (collision.gameObject.tag == "Enemy")
			//{
			//	Destroy(collision.gameObject);
			//}
		}

	}
	public static void BeingDead()
	{
		if (GameObject.Find("MainBean") != null)
		{
			GameObject.Find("MainBean").SetActive(false);
			GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = false;
#if UNITY_ANDROID
			GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
#endif
			GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
		}

	}
}
