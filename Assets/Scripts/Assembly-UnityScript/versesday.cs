using System;
using UnityEngine;

[Serializable]
public class versesday : MonoBehaviour
{
	public bool clicked;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		Application.LoadLevel(4);
		Debug.Log("clicked credits" + ((!clicked) ? " off" : string.Empty));
	}

	public virtual void Main()
	{
	}
}
