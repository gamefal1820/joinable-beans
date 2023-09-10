using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseChecker : MonoBehaviour
{
	static float clicked = 0;
	static float clicktime = 0;
	static float clickdelay = 0.5f;
	public static bool DoubleClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			clicked++;
			if (clicked == 1) clicktime = Time.time;
		}
		if (clicked > 1 && Time.time - clicktime < clickdelay)
		{
			clicked = 0;
			clicktime = 0;
			return true;
		}
		else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
		return false;
	}
	static float startTime = 0;
	public static bool Holding(float holdTime)
	{
		if (Input.GetMouseButtonDown(0)) startTime = Time.time;

		if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
		{
			startTime = 0;
		}
		else if (Time.time - startTime > holdTime)
		{
			return true;
		}
		return false;
	}
	public static string GetGameObjectPath(GameObject obj)
	{
		string path = "/" + obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		return path;
	}
	public static bool Holding()
	{
		if (Input.GetMouseButtonDown(0)) startTime = Time.time;

		if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
		{
			startTime = 0;
			//return false;
		}
		else if (Time.time - startTime > 0.3f)
		{
			return true;
		}
		return false;
	}
	static public bool IsPointerOverUIElement()
	{
		return IsPointerOverUIElement(GetEventSystemRaycastResults());
	}
	static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
	{
		for (int index = 0; index < eventSystemRaysastResults.Count; index++)
		{
			RaycastResult curRaysastResult = eventSystemRaysastResults[index];
			if (curRaysastResult.gameObject.layer == 5)
				return true;
		}
		return false;
	}
	static List<RaycastResult> GetEventSystemRaycastResults()
	{
		PointerEventData eventData = new PointerEventData(EventSystem.current);
		eventData.position = Input.mousePosition;
		List<RaycastResult> raysastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, raysastResults);
		return raysastResults;
	}
}
