using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
	short objects;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 6)
		{
			objects++;
			BeanMovement.isGrounded = true;
		}
		
	}
	private void OnTriggerExit(Collider other)
	{
		
		if (other.gameObject.layer == 6)
		{
			objects--;
			if(objects == 0)
			BeanMovement.isGrounded = false;
		}
		
	}
}
