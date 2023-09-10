using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectsTransformVar : MonoBehaviour
{
	InputField inputField;
	[SerializeField] string objectDemination;
	[SerializeField] string objectTransform;
	bool initialized = false;
	void Start()
	{
		inputField = gameObject.GetComponent<InputField>();
	}

	// Update is called once per frame
	void Update()
	{
		
		if (DetialsManager.ButtonHelding || !initialized)
		{
			if (objectTransform == "P")
			{
				if (objectDemination == "X")
				{
					inputField.text = SelectionManager.Selection.position.x.ToString();
				}
				else if (objectDemination == "Y")
				{
					inputField.text = SelectionManager.Selection.position.y.ToString();
				}
				else if (objectDemination == "Z")
				{
					inputField.text = SelectionManager.Selection.position.z.ToString();
				}
			}
			else if (objectTransform == "R")
			{
				if (objectDemination == "X")
				{
					inputField.text = SelectionManager.Selection.rotation.eulerAngles.x.ToString();
				}
				else if (objectDemination == "Y")
				{
					inputField.text = SelectionManager.Selection.rotation.eulerAngles.y.ToString();
				}
				else if (objectDemination == "Z")
				{
					inputField.text = SelectionManager.Selection.rotation.eulerAngles.z.ToString();
				}
			}
			else if (objectTransform == "S")
			{
				if (objectDemination == "X")
				{
					inputField.text = SelectionManager.Selection.localScale.x.ToString();
				}
				else if (objectDemination == "Y")
				{
					inputField.text = SelectionManager.Selection.localScale.y.ToString();
				}
				else if (objectDemination == "Z")
				{
					inputField.text = SelectionManager.Selection.localScale.z.ToString();
				}
			}

		}
		if (SelectionManager.Selection != null)
		{
			initialized = true;
		}
	}


	public void InputChange(string change)
	{
		if (objectTransform == "P")
		{
			if (objectDemination == "X")
			{
				SelectionManager.Selection.position = new Vector3(float.Parse(change), SelectionManager.Selection.position.y, SelectionManager.Selection.position.z);
			}
			else if (objectDemination == "Y")
			{
				SelectionManager.Selection.position = new Vector3(SelectionManager.Selection.position.x, float.Parse(change), SelectionManager.Selection.position.z);
			}
			else if (objectDemination == "Z")
			{
				SelectionManager.Selection.position = new Vector3(SelectionManager.Selection.position.x, SelectionManager.Selection.position.y, float.Parse(change));
			}
		}
		else if (objectTransform == "R")
		{
			if (objectDemination == "X")
			{
				SelectionManager.Selection.rotation = Quaternion.Euler(float.Parse(change), SelectionManager.Selection.rotation.eulerAngles.y, SelectionManager.Selection.rotation.eulerAngles.z);
			}
			else if (objectDemination == "Y")
			{
				SelectionManager.Selection.rotation = Quaternion.Euler(SelectionManager.Selection.eulerAngles.x, float.Parse(change), SelectionManager.Selection.rotation.eulerAngles.z);
			}
			else if (objectDemination == "Z")
			{
				SelectionManager.Selection.rotation = Quaternion.Euler(SelectionManager.Selection.rotation.eulerAngles.x, SelectionManager.Selection.rotation.eulerAngles.y, float.Parse(change));
			}
		}
		else if (objectTransform == "S")
		{
			if (objectDemination == "X")
			{
				SelectionManager.Selection.localScale = new Vector3(float.Parse(change), SelectionManager.Selection.localScale.y, SelectionManager.Selection.localScale.z);
			}
			else if (objectDemination == "Y")
			{
				SelectionManager.Selection.localScale = new Vector3(SelectionManager.Selection.localScale.x, float.Parse(change), SelectionManager.Selection.localScale.z);
			}
			else if (objectDemination == "Z")
			{
				SelectionManager.Selection.localScale = new Vector3(SelectionManager.Selection.localScale.x, SelectionManager.Selection.localScale.y, float.Parse(change));
			}
		}

	}
	private void OnDisable()
	{
		initialized = false;
	}
}
