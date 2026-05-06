using System;
using UnityEngine;

[Serializable]
public class map : MonoBehaviour
{
	public Texture2D yourtexture;

	public GameObject objecttodestroy;

	public virtual void OnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), yourtexture);
	}

	public virtual void Update()
	{
		if (Input.GetKeyUp("m"))
		{
			UnityEngine.Object.Destroy(objecttodestroy, 0f);
		}
	}

	public virtual void Main()
	{
	}
}
