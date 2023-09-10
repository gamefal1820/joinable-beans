using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
	public static Material DefaultMaterial;
	[SerializeField]  Material HighlightedMaterial;
	
	[HideInInspector] static public Transform Selection;
	[SerializeField] GameObject Detials;
	public GameObject axisarrows;

	void Update()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit) && MouseChecker.DoubleClick() && !MouseChecker.IsPointerOverUIElement() && hit.transform.gameObject.TryGetComponent<Renderer>(out var r))
		{
			//print(hit.transform.gameObject);
			Select(ref hit);
		}
	}
	public void Select(ref RaycastHit hit)
	{
		var _selection = hit.transform;
		if (Selection != _selection && Selection != null)
		{
			Deselect();
		}
		if (Selection == null)
		{
			if (_selection.TryGetComponent<Renderer>(out var selectionRenderer))
			{
				DefaultMaterial = selectionRenderer.material;
				if (selectionRenderer != null)
				{
					selectionRenderer.material = HighlightedMaterial;
				}
				Selection = _selection;
				Detials.SetActive(true);
				//axisarrows.transform.position = Selection.position;
				//axisarrows.SetActive(true);
			}
		}
		else if (Selection == _selection)
		{
			Deselect();
		}
	}	
	public void Select(ref GameObject hit)
	{
		var _selection = hit.transform;
		if (Selection != _selection && Selection != null)
		{
			Deselect();
		}
		if (Selection == null)
		{
			if (_selection.TryGetComponent<Renderer>(out var selectionRenderer))
			{
				DefaultMaterial = selectionRenderer.material;
				if (selectionRenderer != null)
				{
					selectionRenderer.material = HighlightedMaterial;
				}
				Selection = _selection;
				Detials.SetActive(true);
			}
		}
		else if (Selection == _selection)
		{
			Deselect();
		}
	}
	public void Deselect()
	{
		var selectionRenderer = Selection.GetComponent<Renderer>();
		selectionRenderer.material = DefaultMaterial;
		Selection = null;
		DefaultMaterial = null;
		Detials.SetActive(false);
	}
	public void Remove()
	{
		if (Selection != null)
		{
			if (!Selection.CompareTag("Player"))
			{
				Transform toDelete;
				toDelete = Selection;
				Deselect();
				Destroy(toDelete.gameObject);
			}
		}
	}
	public void Duplicate()
	{
		Transform toDuplicate;
		GameObject Duplicated;
		toDuplicate = Selection;
		Deselect();
		Duplicated = Instantiate(toDuplicate.gameObject);
		Select(ref Duplicated);
	}
}
