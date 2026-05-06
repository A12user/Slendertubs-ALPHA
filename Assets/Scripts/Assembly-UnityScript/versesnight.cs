using System;
using UnityEngine;

[Serializable]
public class versesnight : MonoBehaviour
{
	public bool clicked;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		Application.LoadLevel(6);
		Debug.Log("clicked credits" + ((!clicked) ? " off" : string.Empty));
	}

	public virtual void Main()
	{
	}
}
