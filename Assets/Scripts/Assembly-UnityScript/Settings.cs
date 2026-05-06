using System;
using UnityEngine;

[Serializable]
public class Settings : MonoBehaviour
{
	public bool clicked;

	public Camera CameraMenu;

	public Camera CameraSettings;

	public Camera CameraSingleplayer;

	public Camera CameraMultiplayer;

	public Camera CameraCoop;

	public Camera CameraVerses;

	public Transform settingsobject;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		UnityEngine.Object.Instantiate(settingsobject, transform.position, transform.rotation);
		CameraMenu.camera.enabled = false;
		CameraSettings.camera.enabled = true;
		CameraSingleplayer.camera.enabled = false;
		CameraMultiplayer.camera.enabled = false;
		CameraCoop.camera.enabled = false;
		CameraVerses.camera.enabled = false;
	}

	public virtual void Main()
	{
	}
}
