using System;
using UnityEngine;

[Serializable]
public class DoorOpen : MonoBehaviour
{
	[NonSerialized]
	public static int leverswitch;

	public int trigger;

	public Transform Player;

	public GameObject animated;

	public Transform dooractivater;

	public DoorOpen()
	{
		trigger = 1;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		leverswitch = trigger;
		Player.parent = null;
		animated.animation.Play("Take 001");
		bool flag = false;
	}

	public virtual void OnTriggerExit(Collider other)
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
