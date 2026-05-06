using System;
using UnityEngine;

[Serializable]
public class singleplayerday : MonoBehaviour
{
	public bool clicked;

	public virtual void OnMouseDown()
	{
		clicked = !clicked;
		Application.LoadLevel(7);
		Debug.Log("clicked credits" + ((!clicked) ? " off" : string.Empty));
	}

	public virtual void Main()
	{
	}
}
