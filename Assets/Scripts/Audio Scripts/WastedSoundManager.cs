using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastedSoundManager : MonoBehaviour
{
    AudioSource audioSource;
	public AudioSource audioSource2;
	GameObject player;
	bool played;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (!LevelDescription.canTrain)
		{
			if (player.activeSelf == false && !played)
			{
				audioSource2.Stop();
				audioSource.Play();
				played = true;
			}
		}

    }
}
