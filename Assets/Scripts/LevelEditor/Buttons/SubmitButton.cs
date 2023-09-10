using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SubmitButton : MonoBehaviour
{
	public void CustomLevelEditor()
	{
		string Levelname = transform.parent.GetChild(2).GetComponent<InputField>().text;
		string LevelAuthor = transform.parent.GetChild(4).GetComponent<InputField>().text;
		Text errorMessage = transform.parent.GetChild(7).GetComponent<Text>();

		if (Levelname != null || LevelAuthor != null)
		{
			if (!Directory.Exists(Application.persistentDataPath + @"\Levels\" + Levelname))
			{
				GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().LevelPath = Application.persistentDataPath + @"\Levels\" + Levelname;
				GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().Author = LevelAuthor;

				DontDestroyOnLoad(GameObject.Find("CustomLevelManager"));
				Destroy(GameObject.Find("LevelDes"));
				SceneManager.LoadScene("LevelEditor");
			}
			else
			{
				errorMessage.gameObject.SetActive(true);
				errorMessage.text = "you have another level with this name";
			}

		}
	}
}
