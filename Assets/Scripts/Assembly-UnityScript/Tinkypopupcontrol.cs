using System;
using UnityEngine;

[Serializable]
public class Tinkypopupcontrol : MonoBehaviour
{
	public Transform popup1;

	public virtual void Update()
	{
		if (!networkView.isMine)
		{
		}
		Checkbutton();
		bool flag = true;
	}

	public virtual void Checkbutton()
	{
		if (Input.GetKeyDown("1"))
		{
			Network.Instantiate(popup1, transform.position, transform.rotation, 1);
		}
	}

	public virtual void Main()
	{
	}
}
