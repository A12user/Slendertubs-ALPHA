using System;
using UnityEngine;

[Serializable]
public class Gamequit : MonoBehaviour
{
	public virtual void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
	}

	public virtual void Main()
	{
	}
}
