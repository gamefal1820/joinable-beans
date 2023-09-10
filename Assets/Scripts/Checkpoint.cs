using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	CheckpointManager gm;
	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<CheckpointManager>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			gm.LastCheckpoint = transform.position;
		}
	}
}
