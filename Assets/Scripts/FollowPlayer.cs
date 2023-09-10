using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : FriendCollider
{
    
    bool beingTouched;
    
    bool played = false;
    NavMeshAgent NavAg;
    public AudioSource audioSource;
    float playerStoppingDistance;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") beingTouched = true;
    }
    void Start()
    {
        NavAg = GetComponent<NavMeshAgent>();
        playerStoppingDistance = NavAg.stoppingDistance;
        audioSource = GetComponent<AudioSource>();
        Target = GameObject.FindWithTag("Player");
        beingTouchedEnemy = false;
        beingTouched = false;
        NavAg.stoppingDistance = playerStoppingDistance;
    }
    void Update()
    {
        //print(beingTouchedEnemy);
		if (!beingTouched)
		{
            beingTouchedEnemy = false;
		}
		//print(Target);
		if (beingTouched)
		{

			if (Target == null)
			{
				beingTouchedEnemy = false;
				Target = GameObject.FindWithTag("Player");
				NavAg.stoppingDistance = playerStoppingDistance;
			}
			else
			{
				if (beingTouchedEnemy || Target.tag == "Enemy")
                {
                    NavAg.stoppingDistance = 0;
				}
				else if (Target.tag == "Player")
				{
                    NavAg.stoppingDistance = playerStoppingDistance;
				}
                NavAg.SetDestination(Target.transform.position);
				//if ((Target.transform.position.z - transform.position.z) > 10)
				//{
				//    transform.position = new Vector3(Target.transform.position.x
				//        , Target.transform.position.y, Target.transform.position.z - Random.Range(3, 6));
				//}
			}
			//if (beingTouchedEnemy)
			//{
   //             NavAg.stoppingDistance = 0;
			//}
			if (!played)
			{
                audioSource.Play(); 
                played = true;
            }
        }
    }
}
