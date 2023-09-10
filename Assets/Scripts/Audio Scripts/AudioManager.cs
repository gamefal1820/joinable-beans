using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip trainsong;
    AudioSource audioSource;
    public static AudioManager _instance;
    bool AudioBegin;

    void Awake()
    {

    }
    private void Start()
	{
		if (LevelDescription.canTrain)
		{
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                audioSource = transform.GetChild(0).GetComponent<AudioSource>();
                if (!AudioBegin)
                {
                    audioSource.clip = trainsong;
                    //audioSource.Play();

                    audioSource.Play();
                    DontDestroyOnLoad(gameObject);
                    AudioBegin = true;
                }
            }
            if (!_instance)
                _instance = this;
            //otherwise, if we do, kill this thing
            else
                Destroy(this.gameObject);
            transform.GetChild(2).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" && LevelDescription.canTrain)
        {
            Destroy(this.gameObject);
        }
    }
}
