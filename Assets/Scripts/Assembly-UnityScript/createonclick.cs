using System;
using UnityEngine;

[Serializable]
public class createonclick : MonoBehaviour
{
	public bool clicked;

	public Transform spawn;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		UnityEngine.Object.Instantiate(spawn, transform.position, transform.rotation);
	}

	public virtual void Main()
	{
	}
}
