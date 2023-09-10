using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Globalization;

public class LoadCustomLevels : MonoBehaviour
{
	static LoadCustomLevels instance;
	public GameObject ButtonPrefab;
	public Sprite DefaultPNG;
	public Transform ContentGameObject;

	private void Awake()
	{
		instance = this;
	}
	void LoadTheLevels()
	{
		for (int i = 0; i < ContentGameObject.childCount; i++)
			Destroy(ContentGameObject.GetChild(i).gameObject);
		string path = Application.persistentDataPath + @"\Levels";
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		string[] levelPaths = Directory.GetDirectories(path);

		foreach (string item in levelPaths)
		{
			if (File.Exists(item + @"\data") && File.Exists(item + @"\objects"))
			{
				GameObject currentButton = Instantiate(ButtonPrefab, ContentGameObject);

				currentButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = new DirectoryInfo(item).Name;

				currentButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = DefaultPNG;
				if (File.Exists(item + @"\icon.png"))
				{
					Texture2D levelImagetex = new Texture2D(700, 500);
					levelImagetex.LoadImage(File.ReadAllBytes(item + @"\icon.png"));
					currentButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Sprite.Create(levelImagetex, new Rect(0, 0, levelImagetex.width, levelImagetex.height), new Vector2(0.5f, 0.5f));
				}

				SaveSystem.DecryptFile(item + @"\data", item + @"\datatemp");
				string version = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(item + @"\datatemp")).Split(',')[0];

				if (Application.version != version)
					currentButton.transform.GetChild(2).gameObject.GetComponent<Text>().color = new Color32(152, 27, 0, 255);
				currentButton.transform.GetChild(2).gameObject.GetComponent<Text>().text = version;

				long levelSize = 0;
				foreach (var item2 in Directory.GetFiles(item))
				{
					levelSize += new FileInfo(item2).Length;
				}
				levelSize /= 1024;
				currentButton.transform.GetChild(3).gameObject.GetComponent<Text>().text = levelSize.ToString() + "Kb";

				DateTime lastwrite = new FileInfo(item + @"\objects").LastAccessTime;
				if ((DateTime.Now - lastwrite).Days != 0)
					currentButton.transform.GetChild(4).gameObject.GetComponent<Text>().text = (DateTime.Now - lastwrite).Days + " day(s) ago";
				else if ((DateTime.Now - lastwrite).Hours != 0)
					currentButton.transform.GetChild(4).gameObject.GetComponent<Text>().text = (DateTime.Now - lastwrite).Hours + " hour(s) ago";
				else if ((DateTime.Now - lastwrite).Minutes == 0)
					currentButton.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Now";
				else
					currentButton.transform.GetChild(4).gameObject.GetComponent<Text>().text = (DateTime.Now - lastwrite).Minutes + " minute(s) ago";

				string author = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(item + @"\datatemp")).Split(',')[1];
				currentButton.transform.GetChild(5).gameObject.GetComponent<Text>().text = "by: " + author;
				File.Delete(item + @"\datatemp");

				currentButton.GetComponent<Button>().onClick.AddListener(delegate
				{
					SetLevelPanel(new DirectoryInfo(item).Name, version,
						currentButton.transform.GetChild(1).gameObject.GetComponent<Image>().sprite, item
						, lastwrite, author);
				});
			}
		}
	}
	Image levelImage;
	string levelname;
	GameObject LevelPanel;

	public void SetLevelPanel(string _levelname, string version, Sprite levelpng, string path, DateTime lastAccess, string author)
	{
		LevelPanel = GameObject.Find("Canvas").transform.GetChild(1).GetChild(2).GetChild(4).gameObject;
		//----------------------------------------------------------------------------------------------
		LevelPanel.transform.GetChild(0).GetComponent<Image>().sprite = levelpng;
		LevelPanel.transform.GetChild(1).GetComponent<Text>().text = _levelname;
		if (Application.version != version)
			LevelPanel.transform.GetChild(6).gameObject.GetComponent<Text>().color = new Color32(152, 27, 0, 255);
		LevelPanel.transform.GetChild(6).gameObject.GetComponent<Text>().text = version;

		if ((DateTime.Now - lastAccess).Days != 0)
			LevelPanel.transform.GetChild(5).gameObject.GetComponent<Text>().text = (DateTime.Now - lastAccess).Days + " day(s) ago";
		else if ((DateTime.Now - lastAccess).Hours != 0)
			LevelPanel.transform.GetChild(5).gameObject.GetComponent<Text>().text = (DateTime.Now - lastAccess).Hours + " hour(s) ago";
		else if ((DateTime.Now - lastAccess).Minutes == 0)
			LevelPanel.transform.GetChild(5).gameObject.GetComponent<Text>().text = "Now";
		else
			LevelPanel.transform.GetChild(5).gameObject.GetComponent<Text>().text = (DateTime.Now - lastAccess).Minutes + " minute(s) ago";
		LevelPanel.transform.GetChild(7).GetComponent<Text>().text = author;

		LevelPanel.transform.GetChild(2).GetComponent<Button>().onClick
	.RemoveAllListeners();
		LevelPanel.transform.GetChild(3).GetComponent<Button>().onClick
	.RemoveAllListeners();

		LevelPanel.transform.GetChild(2).GetComponent<Button>().onClick
			.AddListener(delegate { CustomButton(path, false); });
		LevelPanel.transform.GetChild(3).GetComponent<Button>().onClick
	.AddListener(delegate { CustomButton(path, true); });
		LevelPanel.SetActive(true);
	}
	public void CustomButton(string path, bool isEdit)
	{
		if (Directory.Exists(path))
		{
			GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().LevelPath = path;
			GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().IsEdit = isEdit;

			DontDestroyOnLoad(GameObject.Find("CustomLevelManager"));
			Destroy(GameObject.Find("LevelDes"));
			if (!isEdit)
				SceneManager.LoadScene("LevelPlayer");
			else
				SceneManager.LoadScene("LevelEditor");
		}
	}
	public static void LoadLevels()
	{
		instance.LoadTheLevels();
	}
}
