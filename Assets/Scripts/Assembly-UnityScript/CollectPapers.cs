using System;
using UnityEngine;

[Serializable]
public class CollectPapers : MonoBehaviour
{
	public int Paper;

	public int paperToWin;

	public Transform allpapersobj;

	public Transform winobj1;

	public Transform winobj2;

	public Transform winobj3;

	public Transform winobj4;

	public Transform winobj5;

	public Transform winobj6;

	public Transform winobj7;

	public Transform winobj8;

	public Transform winobj9;

	public CollectPapers()
	{
		paperToWin = 5;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Paper")
		{
			Paper++;
			UnityEngine.Object.Destroy(other.gameObject);
			Debug.Log("A paper was picked up. Total papers = " + Paper);
		}
		if (Paper == paperToWin)
		{
			Network.Instantiate(allpapersobj, transform.position, transform.rotation, 1);
		}
		if (Paper == 1)
		{
			Network.Instantiate(winobj1, transform.position, transform.rotation, 1);
		}
		if (Paper == 2)
		{
			Network.Instantiate(winobj2, transform.position, transform.rotation, 1);
		}
		if (Paper == 3)
		{
			Network.Instantiate(winobj3, transform.position, transform.rotation, 1);
		}
		if (Paper == 4)
		{
			Network.Instantiate(winobj4, transform.position, transform.rotation, 1);
		}
		if (Paper == 5)
		{
			Network.Instantiate(winobj5, transform.position, transform.rotation, 1);
		}
		if (Paper == 6)
		{
			Network.Instantiate(winobj6, transform.position, transform.rotation, 1);
		}
		if (Paper == 7)
		{
			Network.Instantiate(winobj7, transform.position, transform.rotation, 1);
		}
		if (Paper == 8)
		{
			Network.Instantiate(winobj8, transform.position, transform.rotation, 1);
		}
		if (Paper == 9)
		{
			Network.Instantiate(winobj9, transform.position, transform.rotation, 1);
		}
	}

	public virtual void Main()
	{
	}
}
