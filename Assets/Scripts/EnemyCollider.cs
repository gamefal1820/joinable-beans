using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
	public bool SomethingTouched = false;

	void Start()
	{
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            EnemyManager.Target = other.transform;
			SomethingTouched = true;
			//print(other.tag);
		}
	}
}
