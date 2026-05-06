using System;
using UnityEngine;

[Serializable]
public class spawnvictumgui : MonoBehaviour
{
	public Transform helpless;

	public virtual void Start()
	{
		Network.Instantiate(helpless, transform.position, transform.rotation, 1);
	}

	public virtual void Main()
	{
	}
}
