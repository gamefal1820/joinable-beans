using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	public GameObject singletonTempGameObject;
	static public GameObject tempGameObject;

	void Start()
	{
		tempGameObject = singletonTempGameObject;
	}
	public static void SaveLevel()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().LevelPath;
		if (!Directory.Exists(Application.persistentDataPath + @"\Levels"))
			Directory.CreateDirectory(Application.persistentDataPath + @"\Levels");
		if (Directory.Exists(path))
		{
			foreach (var item in Directory.GetFiles(path))
			{
				File.Delete(item);
			}
			Directory.Delete(path);
		}
		Directory.CreateDirectory(path);

		FileStream objectStream = new FileStream(path + @"\objects", FileMode.Create);

		LevelData data = new LevelData();
		//if(File.Exists())
		formatter.Serialize(objectStream, data);
		objectStream.Close();
		ScreenshotHandler.SavePath = path + @"\icon.png";
		ScreenshotHandler.TakeShot(500, 700);

		string dataString = null;
		dataString += Application.version + ",";
		dataString += GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().Author + ",";
		byte[] dataByte = Encoding.UTF8.GetBytes(dataString);
		FileStream dataStream = new FileStream(path + @"\datatemp", FileMode.Create);
		dataStream.Write(dataByte, 0, dataByte.Length);
		dataStream.Close();
		EncryptFile(path + @"\datatemp", path + @"\data");
		File.Delete(path + @"\datatemp");
	}
	public static void SaveTempLevel()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + @"\temp";
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		if (File.Exists(path + @"\data"))
			File.Delete(path + @"\data");		
		if (File.Exists(path + @"\datatemp"))
			File.Delete(path + @"\datatemp");		
		if (File.Exists(path + @"\icon.png"))
			File.Delete(path + @"\icon.png");		
		if (File.Exists(path + @"\objects"))
			File.Delete(path + @"\objects");
		FileStream objectStream = new FileStream(path + @"\objects", FileMode.Create);

		LevelData data = new LevelData();
		//if(File.Exists())
		formatter.Serialize(objectStream, data);
		objectStream.Close();
		ScreenshotHandler.SavePath = path + @"\icon.png";
		ScreenshotHandler.TakeShot(500, 700);

		string dataString = null;
		dataString += Application.version + ",";
		dataString += GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().Author + ",";
		byte[] dataByte = Encoding.UTF8.GetBytes(dataString);
		FileStream dataStream = new FileStream(path + @"\datatemp", FileMode.Create);
		dataStream.Write(dataByte, 0, dataByte.Length);
		dataStream.Close();
		EncryptFile(path + @"\datatemp", path + @"\data");
		File.Delete(path + @"\datatemp");

		GameObject temp = Instantiate(tempGameObject);
		DontDestroyOnLoad(temp);
		UnityEngine.SceneManagement.SceneManager.LoadScene("LevelPlayer");
	}

	public static LevelData LoadLevel()
	{
		string path = GameObject.Find("CustomLevelManager").GetComponent<CustomLevelManage>().LevelPath + @"\objects";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			LevelData data = formatter.Deserialize(stream) as LevelData;
			stream.Close();
			return data;
		}
		else
		{
			Debug.LogError(path + " Get Noobed");
			return null;
		}
	}	
	public static LevelData LoadtempLevel()
	{
		string path = Application.persistentDataPath + @"\temp\objects";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			LevelData data = formatter.Deserialize(stream) as LevelData;
			stream.Close();
			return data;
		}
		else
		{
			Debug.LogError(path + " Get Noobed");
			return null;
		}

	}

	public static void EncryptFile(string inputFile, string outputFile)
	{

		try
		{
			string password = @"haoeb435"; // Your Key Here
			UnicodeEncoding UE = new UnicodeEncoding();
			byte[] key = UE.GetBytes(password);

			string cryptFile = outputFile;
			FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

			RijndaelManaged RMCrypto = new RijndaelManaged();

			CryptoStream cs = new CryptoStream(fsCrypt,
				RMCrypto.CreateEncryptor(key, key),
				CryptoStreamMode.Write);

			FileStream fsIn = new FileStream(inputFile, FileMode.Open);

			int data;
			while ((data = fsIn.ReadByte()) != -1)
				cs.WriteByte((byte)data);


			fsIn.Close();
			cs.Close();
			fsCrypt.Close();
		}
		catch
		{
			print("afsaefs");
		}
	}
	///<summary>
	/// Steve Lydford - 12/05/2008.
	///
	/// Decrypts a file using Rijndael algorithm.
	///</summary>
	///<param name="inputFile"></param>
	///<param name="outputFile"></param>
	public static void DecryptFile(string inputFile, string outputFile)
	{

		string password = @"haoeb435"; // Your Key Here

		UnicodeEncoding UE = new UnicodeEncoding();
		byte[] key = UE.GetBytes(password);

		FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

		RijndaelManaged RMCrypto = new RijndaelManaged();

		CryptoStream cs = new CryptoStream(fsCrypt,
			RMCrypto.CreateDecryptor(key, key),
			CryptoStreamMode.Read);

		FileStream fsOut = new FileStream(outputFile, FileMode.Create);

		int data;
		while ((data = cs.ReadByte()) != -1)
			fsOut.WriteByte((byte)data);

		fsOut.Close();
		cs.Close();
		fsCrypt.Close();

	}
}
