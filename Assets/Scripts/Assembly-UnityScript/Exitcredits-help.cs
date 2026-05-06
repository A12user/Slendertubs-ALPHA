using System;
using UnityEngine;

[Serializable]
public class Exitcredits_0026help : MonoBehaviour
{
	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Transform transform = GameObject.FindWithTag("Creditsandhelp").transform;
			UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
