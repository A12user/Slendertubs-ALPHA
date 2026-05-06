using System;
using UnityEngine;

[Serializable]
public class singleplayernight : MonoBehaviour
{
	public bool clicked;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		Application.LoadLevel(9);
		Debug.Log("clicked credits" + ((!clicked) ? " off" : string.Empty));
	}

	public virtual void Main()
	{
	}
}
