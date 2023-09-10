using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : EnemyCollider
{
	public float LookRaduius = 10f;
	public static Transform Target;
	public NavMeshAgent navMesh;
	
	//Collider DetectCollider;


	void Start()
	{
		//DetectCollider = GetComponentInChildren<Collider>();
		navMesh = GetComponent<NavMeshAgent>();
		Target = null;
		SomethingTouched = false;
	}
	private void Update()
	{
		//navMesh = GetComponent<NavMeshAgent>();
		//float Distance = Vector3.Distance(Target.position, transform.position);
		
		if (/*Distance <= LookRaduius*/SomethingTouched)
		{
			navMesh.SetDestination(Target.position);
		}
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, LookRaduius);
	}
}
