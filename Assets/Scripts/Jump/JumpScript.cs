using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumpScript : MonoBehaviour
{
    public NavMeshLink link;
    public Transform looksposition;

    void Update()
    {
        link.width = transform.localScale.x;
        //looksposition.localScale = new Vector3(transform.localScale.x * 7, 1);        
        link.startPoint = new Vector3(link.startPoint.x,link.startPoint.y, transform.localScale.z * -2.5f);
        link.startPoint = new Vector3(link.startPoint.x,link.startPoint.y, transform.localScale.z * 2.5f);
        //looksposition.localScale = new Vector3(looksposition.localScale.x, transform.localScale.y * 37);
    }
}
