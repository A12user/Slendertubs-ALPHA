using System;
using UnityEngine;

[Serializable]
public class Returntomainmenu : MonoBehaviour
{
	public virtual void OnGUI()
	{
		if (GUI.Button(new Rect(0f, 0f, 800f, 20f), "Return to the main menu"))
		{
			Debug.Log("clicked credits");
			Application.LoadLevel(0);
		}
	}

	public virtual void Main()
	{
	}
}
