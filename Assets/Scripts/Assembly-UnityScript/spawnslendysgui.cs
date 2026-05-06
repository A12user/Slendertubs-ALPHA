using System;
using UnityEngine;

[Serializable]
public class spawnslendysgui : MonoBehaviour
{
	public Transform guis;

	public Transform protect;

	public virtual void Start()
	{
		UnityEngine.Object.Instantiate(guis, transform.position, transform.rotation);
		UnityEngine.Object.Instantiate(protect, transform.position, transform.rotation);
	}

	public virtual void Main()
	{
	}
}
