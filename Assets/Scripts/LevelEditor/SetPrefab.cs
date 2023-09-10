using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPrefab : MonoBehaviour
{
	public GameObject Prefab;
	//public Sprite Loading;

	//void Start()
	//{
	//	StartCoroutine(AssetPreviewLoad());
	//}
	//Texture2D texture2D;
	//IEnumerator AssetPreviewLoad()
	//{
	//	yield return null;
	//	Sprite sprite = Loading;
	//	transform.GetChild(0).GetComponent<Image>().sprite = sprite;
	//	//while (texture2D == null)
	//	//{
	//	//	texture2D = ;
	//	//	yield return null;
	//	//}
	//	sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
	//	transform.GetChild(0).GetComponent<Image>().sprite = sprite;
	//}
	public void InstantiatePrefab()
	{
		Instantiate(Prefab, Camera.main.transform.GetChild(0).position, new Quaternion());
	}
}
