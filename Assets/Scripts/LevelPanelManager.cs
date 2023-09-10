using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelManager : MonoBehaviour
{
	Image levelImage;
	string levelname;
	GameObject LevelPanel;

	public void SetLevelPanel(int levelNumber)
	{
		levelImage = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(levelNumber).GetChild(1)
			.GetComponent<Image>();		
		levelname = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(levelNumber).GetChild(0)
			.GetComponent<Text>().text;
		LevelPanel = transform.GetChild(1).gameObject;
		//----------------------------------------------------------------------------------------------
		LevelPanel.transform.GetChild(0).GetComponent<Image>().sprite = levelImage.sprite;
		LevelPanel.transform.GetChild(1).GetComponent<Text>().text = levelname;
		LevelPanel.SetActive(true);
		//----------------------------------------------------------------------------------------------

	}	
	

	public void RegularGetClicked()
	{
		LevelDescription.canTrain = false;
		SceneManager.LoadScene(levelImage.sprite.name.Remove(7));
	}
	public void TrainingGetClicked()
	{
		LevelDescription.canTrain = true;
		SceneManager.LoadScene(levelImage.sprite.name.Remove(7));
	}
}
