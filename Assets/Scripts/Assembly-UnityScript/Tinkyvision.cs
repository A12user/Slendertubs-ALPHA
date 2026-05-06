using System;
using UnityEngine;

[Serializable]
public class Tinkyvision : MonoBehaviour
{
	public virtual void Start()
	{
		RenderSettings.fog = !RenderSettings.fog;
	}

	public virtual void Main()
	{
	}
}
