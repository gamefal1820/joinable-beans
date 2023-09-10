using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTeleport : MonoBehaviour
{
	public Transform SpawnPoint;
	public BeanMovement PlayerBeanMovement;
	public CharacterController Playercharacter;

	private void OnTriggerEnter(Collider other)
	{
		PlayerBeanMovement.enabled = false;
		Playercharacter.enabled = false;
		other.transform.position = SpawnPoint.position;
		PlayerBeanMovement.enabled = true;
		Playercharacter.enabled = true;
		//StartCoroutine(Teleporter(other));
	}
	//IEnumerator Teleporter(Collider other)
	//{
	//	PlayerBeanMovement.enabled = false;
	//	yield return new WaitForSeconds(0.1f);
	//	other.transform.position = SpawnPoint.position;
	//	yield return new WaitForSeconds(0.1f);
	//	PlayerBeanMovement.enabled = true;
	//}
}
