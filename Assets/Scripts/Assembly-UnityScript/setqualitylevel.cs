using System;
using UnityEngine;

[Serializable]
public class setqualitylevel : MonoBehaviour
{
	public virtual void OnGUI()
	{
		GUI.Box(new Rect(10f, 10f, 200f, 1000f), "Graphics Resolution");
		if (GUI.Button(new Rect(20f, 40f, 80f, 20f), "Fastest"))
		{
			QualitySettings.currentLevel = QualityLevel.Fastest;
		}
		if (GUI.Button(new Rect(20f, 70f, 80f, 20f), "Fast"))
		{
			QualitySettings.currentLevel = QualityLevel.Fast;
		}
		if (GUI.Button(new Rect(20f, 100f, 80f, 20f), "Simple"))
		{
			QualitySettings.currentLevel = QualityLevel.Simple;
		}
		if (GUI.Button(new Rect(20f, 130f, 80f, 20f), "Good"))
		{
			QualitySettings.currentLevel = QualityLevel.Good;
		}
		if (GUI.Button(new Rect(20f, 160f, 80f, 20f), "Beautiful"))
		{
			QualitySettings.currentLevel = QualityLevel.Beautiful;
		}
		if (GUI.Button(new Rect(20f, 190f, 80f, 20f), "Fantastic"))
		{
			QualitySettings.currentLevel = QualityLevel.Fantastic;
		}
	}

	public virtual void Main()
	{
	}
}
