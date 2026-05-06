using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class optionsMenu : MonoBehaviour
{
	public static bool showMenu;

	private string settings;

	public static float ambianceLevel;

	public static bool fullscreen;

	public static string screenres = "1";

	private string curRes = "1";

	private void Start()
	{
		string[] array = Regex.Split(settings, "\r\n");
		string[] array2 = array;
		foreach (string input in array2)
		{
			string[] array3 = Regex.Split(input, "=");
			if (array3[0] == "ambiance")
			{
				ambianceLevel = float.Parse(array3[1]);
			}
			else if (array3[0] == "fullscreen")
			{
				if (array3[1] == "True" || array3[1] == "true")
				{
					Screen.fullScreen = true;
					fullscreen = true;
				}
				else
				{
					Screen.fullScreen = false;
				}
			}
			else if (array3[0] == "screenresolution")
			{
				switch (array3[1])
				{
				case "1":
					Screen.SetResolution(1366, 768, fullscreen);
					break;
				case "2":
					Screen.SetResolution(1600, 900, fullscreen);
					break;
				}
				screenres = array3[1];
			}
		}
	}

	private void Update()
	{
		if (curRes != screenres)
		{
			switch (screenres)
			{
			case "1":
				Screen.SetResolution(1366, 768, fullscreen);
				break;
			case "2":
				Screen.SetResolution(1600, 900, fullscreen);
				break;
			}
			curRes = screenres;
		}
		if (Screen.fullScreen != fullscreen)
		{
			Screen.fullScreen = fullscreen;
		}
	}

	public void OnGUI()
	{
		GUI.depth = 1000;
		if (showMenu)
		{
			GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300f, 300f), string.Empty);
			GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300f, 300f), "Sound");
			GUI.Label(new Rect(Screen.width / 2 - 145, Screen.height / 2 - 130, 300f, 300f), "Ambience");
			GUI.Label(new Rect(Screen.width / 2 + 115, Screen.height / 2 - 130, 300f, 300f), (int)(ambianceLevel * 100f) + "%");
			ambianceLevel = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 125, 190f, 50f), ambianceLevel, 0f, 1f);
			GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300f, 300f), "Graphics");
			fullscreen = GUI.Toggle(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 80, 200f, 30f), fullscreen, "Fullscreen");
			if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 110, 120f, 30f), "Close"))
			{
				showMenu = false;
				saveSettings();
			}
		}
		GUI.depth = 0;
	}

	public static void saveSettings()
	{
		string text = "ambiance=" + (int)(ambianceLevel * 100f);
		text = text + "\r\nfullscreen=" + fullscreen;
		text = text + "\r\nscreenresolution=" + screenres;
		StreamWriter streamWriter = new StreamWriter("settings.ini");
		streamWriter.Write(text);
		streamWriter.Close();
	}
}
