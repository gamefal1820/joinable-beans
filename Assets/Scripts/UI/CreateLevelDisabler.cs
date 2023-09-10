using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevelDisabler : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        gameObject.SetActive(false);
#endif
    }
}
