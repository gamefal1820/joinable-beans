/*
 *	Author: Anastasios Chouliaropoulos
 * 
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour 
{
	
	public float patrolSpeed = 2f;									// The nav mesh agent's speed when patrolling.
	
	private List<Transform> wpnts = new List<Transform>();
	private int randomIndex;
	private int countIndex;
	private UnityEngine.AI.NavMeshAgent _agent;
	
	public Transform[] waypoints;
	
	void Awake () 
	{
		// inits
		_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		
		// Keep wpnts on a list
		foreach (Transform tr in waypoints) 
		{
				wpnts.Add(tr);
		}
		
		// cache the number of wpnts
		countIndex = wpnts.Count;
		randomIndex = Random.Range(0, countIndex);
	}
	
	// Update is called once per frame
	void Update () 
	{
			if (!_agent.hasPath) 
			{
				patrol ();
			}
			// offset between the enemy and the waypoint
			else if (_agent.remainingDistance < 1) 
			{
				_agent.ResetPath();
			}
	}
	
	public void patrol() 
	{
		// Set an appropriate speed for the NavMeshAgent.
		_agent.speed = patrolSpeed;
		
		// go to the next waypoint, use of modulo to get the correct numbers on every iteration
		_agent.SetDestination(wpnts[randomIndex%countIndex].position);
		randomIndex = Random.Range(0, countIndex);
	}
}
