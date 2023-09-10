using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
	GameUI beanInput;

	public static bool GameIsPaused = false;
    public GameObject PauseUI;
    public GameObject GameUI;

	private void Awake()
	{
        beanInput = new GameUI();
	}
	void OnEnable()
	{
		beanInput.UI.Pause.started += WantPause;
		beanInput.UI.Pause.Enable();
	}
	private void OnDisable()
	{
		if (beanInput.UI.Pause != null)
			beanInput.UI.Pause.Disable();
	}

	private void WantPause(InputAction.CallbackContext obj)
	{
        if (GameIsPaused)
            Resume();
        else
            Paused();
	}

	private void Paused()
	{
        PauseUI.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0;
	}

	public void Resume()
	{
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
    }
}
