using System;
using UnityEngine;

[Serializable]
public class flashlight : MonoBehaviour
{
	public GameObject flashlight;

	public AudioClip switchsound;

	public Light myLight;

	public flashlight()
	{
		myLight = (Light)flashlight.GetComponent("Light");
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("f"))
		{
			myLight.enabled = !myLight.enabled;
			audio.PlayOneShot(switchsound);
		}
		if (Input.GetMouseButtonDown(1))
		{
			myLight.enabled = !myLight.enabled;
			audio.PlayOneShot(switchsound);
		}
	}

	public virtual void Main()
	{
	}
}
