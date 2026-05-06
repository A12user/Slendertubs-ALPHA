using System;
using UnityEngine;

[Serializable]
public class Popup_0020gui_0020script : MonoBehaviour
{
	public Texture2D yourtexture;

	public AudioClip popupsound;

	public virtual void Update()
	{
		audio.clip = popupsound;
		audio.Play();
	}

	public virtual void OnGUI()
	{
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), yourtexture);
	}

	public virtual void Main()
	{
	}
}
