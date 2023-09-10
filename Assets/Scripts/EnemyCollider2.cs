using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider2 : MonoBehaviour
{
	CameraFollow _camera;
	public GameObject GamePanel;
	public GameObject WastedPanel;

    private void Awake()
    {
		GamePanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
		WastedPanel = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
	}

    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			_camera = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
			GamePanel = GameObject.Find("GamePanel");
			_camera.enabled = false;
			other.gameObject.SetActive(false);
#if UNITY_ANDROID
			GamePanel.SetActive(false);
#endif
			WastedPanel.SetActive(true);
		}
		else if (other.gameObject.tag == "Friend")
		{
			//print("EnemyCo");
			//Destroy(other.gameObject);
			//Destroy(gameObject);
		}
	}
}
