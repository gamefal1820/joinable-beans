using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsOptions : MonoBehaviour
{
	public bool NoClip;
	public bool Invisible;
	public bool KillPlayer;
	public enum ObjectColors
	{
		Default, BleachedCedar, Purple, Lava, Brown, Red, Yellow, Orange, Lime, Faded, FadedLightBlue, Magenta
	}
	public ObjectColors Color;
}
