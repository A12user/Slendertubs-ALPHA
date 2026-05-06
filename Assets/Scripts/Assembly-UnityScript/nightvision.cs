using System;
using UnityEngine;

[Serializable]
public class nightvision : MonoBehaviour
{
	public GameObject flashlight;

	public AudioClip switchsound;

	public Light myLight;

	public nightvision()
	{
		myLight = (Light)flashlight.GetComponent("Light");
	}

	public virtual void Update()
	{
		if (networkView.isMine && Input.GetKeyDown("n"))
		{
			myLight.enabled = !myLight.enabled;
			audio.PlayOneShot(switchsound);
		}
	}

	public virtual void Main()
	{
	}
}
