using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtunManager : MonoBehaviour
{

	public void ExitVoid()
	{
		Application.Quit();
	}


	public void RetryButton()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}	


	public void BackButtonForLevels()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
}
