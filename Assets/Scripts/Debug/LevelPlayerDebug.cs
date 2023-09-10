using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayerDebug : MonoBehaviour
{
    public Text Isgrounded;
    public Text wallCheck;

    // Update is called once per frame
    void Update()
    {
        wallCheck.text = "wallCheck = " + BeanMovement.aBarrierAhead.ToString();
        Isgrounded.text = "IsGrounded = " + BeanMovement.isGrounded.ToString();
    }
}
