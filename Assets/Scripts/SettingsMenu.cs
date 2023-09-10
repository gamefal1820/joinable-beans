using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Dropdown dropdown;
	public Slider slider;
	public Text storage;

	public void SetVolume(float Volume)
	{
		audioMixer.SetFloat("volume", Volume);
	}
	public void Start()
	{
		float value;
		dropdown.value = QualitySettings.GetQualityLevel();
		audioMixer.GetFloat("volume", out value);
		slider.value = value;
		storage.text = "Custom Levels folder:\n" + Application.persistentDataPath + "/Levels";
	}
	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	public void CopyToClipboard()
	{
		GUIUtility.systemCopyBuffer = Application.persistentDataPath + "/Levels";
	}
}
