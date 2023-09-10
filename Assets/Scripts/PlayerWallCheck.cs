using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheck : MonoBehaviour
{
	short objects;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 6)
		{
			if (!other.isTrigger)
			{
				objects++;
				BeanMovement.aBarrierAhead = true;
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 6)
		{
			if (other.gameObject.layer == 6)
			{
				objects--;
				if (objects == 0)
					BeanMovement.aBarrierAhead = false;
			}
		}
	}
}
