using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCollider : MonoBehaviour
{
	[SerializeField] public bool beingTouchedEnemy = false;
	public GameObject Target;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy"/* && (other.transform.position.z - transform.position.z) > 7*/)
		{
			beingTouchedEnemy = true;
			Target = other.gameObject;
			
		}
		//print(other.tag);
	}
}
