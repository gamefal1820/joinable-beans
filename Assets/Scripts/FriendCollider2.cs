using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCollider2 : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			//print("Entered");
			Destroy(other.gameObject.transform.parent.gameObject);
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
