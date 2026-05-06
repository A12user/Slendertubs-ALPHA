using System;
using UnityEngine;

[Serializable]
public class togglevision : MonoBehaviour
{
	public Transform NoFog;

	public AudioClip switchsound;

	public virtual void Update()
	{
		if (Input.GetKeyDown("f"))
		{
			audio.PlayOneShot(switchsound);
			UnityEngine.Object.Instantiate(NoFog, transform.position, transform.rotation);
		}
		if (Input.GetMouseButtonDown(1))
		{
			audio.PlayOneShot(switchsound);
			UnityEngine.Object.Instantiate(NoFog, transform.position, transform.rotation);
		}
	}

	public virtual void Main()
	{
	}
}
