using System;
using UnityEngine;

[Serializable]
public class EnemyScriptPlayer : MonoBehaviour
{
	public Transform thePlayer;

	private Transform theEnemy;

	public float speed;

	public bool isOffScreen;

	public float offscreenDotRange;

	public bool isVisible;

	public float visibleDotRange;

	public bool isInRange;

	public float followDistance;

	public float maxVisibleDistance;

	private float sqrDist;

	public float health;

	public float damage;

	public AudioClip nearbyaudio;

	public GameObject triggerTarget;

	public Texture replacementTex;

	public Texture originalTex;

	public Texture2D blackness;

	public Texture2D scare;

	public Transform endgamepopup;

	public EnemyScriptPlayer()
	{
		speed = 5f;
		offscreenDotRange = 0.7f;
		visibleDotRange = 0.8f;
		followDistance = 3f;
		maxVisibleDistance = 25f;
		health = 100f;
		damage = 20f;
	}

	public virtual void Start()
	{
		if (thePlayer == null)
		{
			thePlayer = GameObject.FindWithTag("Player").transform;
		}
		theEnemy = transform;
	}

	public virtual void Update()
	{
		thePlayer = GameObject.FindWithTag("Player").transform;
		CheckIfOffScreen();
		if (isOffScreen)
		{
			MoveEnemy();
			return;
		}
		thePlayer = GameObject.FindWithTag("Player").transform;
		CheckIfVisible();
		if (isVisible)
		{
			DeductHealth();
			StopEnemy();
			return;
		}
		CheckMaxVisibleRange();
		if (!isInRange)
		{
			MoveEnemy();
		}
		else
		{
			StopEnemy();
		}
	}

	public virtual void DeductHealth()
	{
		health -= damage * Time.deltaTime;
		triggerTarget.renderer.material.mainTexture = replacementTex;
		if (!audio.isPlaying)
		{
			audio.clip = nearbyaudio;
			audio.Play();
		}
		if (!(health > 0f))
		{
			Network.Instantiate(endgamepopup, transform.position, transform.rotation, 1);
			UnityEngine.Object.DestroyObject(gameObject);
			health = 0f;
			Debug.Log("YOU ARE OUT OF HEALTH !");
		}
	}

	public virtual void CheckIfOffScreen()
	{
		Vector3 normalized = thePlayer.forward.normalized;
		Vector3 normalized2 = (theEnemy.position - thePlayer.position).normalized;
		float num = Vector3.Dot(normalized, normalized2);
		if (!(num >= offscreenDotRange))
		{
			isOffScreen = true;
		}
		else
		{
			isOffScreen = false;
		}
	}

	public virtual void MoveEnemy()
	{
		CheckDistance();
		if (isInRange)
		{
			StopEnemy();
		}
	}

	public virtual void StopEnemy()
	{
		rigidbody.velocity = Vector3.zero;
	}

	public virtual void CheckIfVisible()
	{
		Vector3 normalized = thePlayer.forward.normalized;
		Vector3 normalized2 = (theEnemy.position - thePlayer.position).normalized;
		float num = Vector3.Dot(normalized, normalized2);
		if (!(num <= visibleDotRange))
		{
			CheckMaxVisibleRange();
			if (isInRange)
			{
				RaycastHit hitInfo = default(RaycastHit);
				if (Physics.Linecast(theEnemy.position, thePlayer.position, out hitInfo) && hitInfo.collider.gameObject.tag == "Player")
				{
					isVisible = true;
				}
			}
			else
			{
				isVisible = false;
			}
		}
		else
		{
			isVisible = false;
		}
	}

	public virtual void CheckDistance()
	{
		float sqrMagnitude = (theEnemy.position - thePlayer.position).sqrMagnitude;
		float num = followDistance * followDistance;
		if (!(sqrMagnitude >= num))
		{
			isInRange = true;
			return;
		}
		isInRange = false;
		triggerTarget.renderer.material.mainTexture = originalTex;
	}

	public virtual void CheckMaxVisibleRange()
	{
		float sqrMagnitude = (theEnemy.position - thePlayer.position).sqrMagnitude;
		float num = maxVisibleDistance * maxVisibleDistance;
		if (!(sqrMagnitude >= num))
		{
			isInRange = true;
		}
		else
		{
			isInRange = false;
		}
	}

	public virtual void Main()
	{
	}
}
