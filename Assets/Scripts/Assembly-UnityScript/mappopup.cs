using System;
using UnityEngine;

[Serializable]
public class mappopup : MonoBehaviour
{
	public Transform ifseesobject;

	public virtual void Update()
	{
		if (Input.GetKeyDown("m"))
		{
			UnityEngine.Object.Instantiate(ifseesobject, transform.position, transform.rotation);
		}
	}

	public virtual void Main()
	{
	}
}
