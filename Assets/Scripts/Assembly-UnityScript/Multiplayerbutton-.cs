using System;
using UnityEngine;

[Serializable]
public class Multiplayerbutton_0023 : MonoBehaviour
{
	public bool clicked;

	public Camera CameraMenu;

	public Camera CameraSettings;

	public Camera CameraSingleplayer;

	public Camera CameraMultiplayer;

	public Camera CameraCoop;

	public Camera CameraVerses;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		CameraMenu.camera.enabled = false;
		CameraSettings.camera.enabled = false;
		CameraSingleplayer.camera.enabled = false;
		CameraMultiplayer.camera.enabled = true;
		CameraCoop.camera.enabled = false;
		CameraVerses.camera.enabled = false;
	}

	public virtual void Main()
	{
	}
}
