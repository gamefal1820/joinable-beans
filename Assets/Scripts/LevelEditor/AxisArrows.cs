using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisArrows : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        transform.GetChild(0).localScale = new Vector3(SelectionManager.Selection.localScale.x * 1.5f, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
        transform.GetChild(0).GetChild(0).position = new Vector3(SelectionManager.Selection.localScale.x * 1.5f * 2, transform.GetChild(0).GetChild(0).localScale.y, transform.GetChild(0).GetChild(0).localScale.z); ;
        //transform.GetChild(1).localScale = SelectionManager.Selection.localScale + new Vector3(3,3,3);
        //transform.GetChild(2).localScale = SelectionManager.Selection.localScale + new Vector3(3,3,3);
        transform.GetChild(0).position = SelectionManager.Selection.localScale + new Vector3(3, 3, 3) * 1.5f;
        //transform.GetChild(1).position = SelectionManager.Selection.localScale + new Vector3(3,3,3) / 2;
        //transform.GetChild(2).position = SelectionManager.Selection.localScale + new Vector3(3,3,3) / 2;
    }
}
