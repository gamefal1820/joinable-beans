using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBeanDeadzone : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy")
		{
			Destroy(collider.transform.parent.gameObject);
		}
	}
}
