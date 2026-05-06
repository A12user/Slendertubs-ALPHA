using System;
using UnityEngine;

[Serializable]
public class disconnect_0026endwon : MonoBehaviour
{
	public float timeOut;

	public bool detachChildren;

	public disconnect_0026endwon()
	{
		timeOut = 5f;
	}

	public virtual void Awake()
	{
		Invoke("DestroyNow", timeOut);
	}

	public virtual void DestroyNow()
	{
		if (detachChildren)
		{
			transform.DetachChildren();
		}
		Network.Disconnect();
		MasterServer.UnregisterHost();
		Application.LoadLevel(10);
	}

	public virtual void Main()
	{
	}
}
