using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GamePanelDisabler : MonoBehaviour
{
	private void OnEnable()
	{
#if UNITY_STANDALONE
		gameObject.SetActive(false);
#endif
	}

}
