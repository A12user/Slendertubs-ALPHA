using System;
using UnityEngine;

[Serializable]
public class crouch_0020and_0020run : MonoBehaviour
{
	public float walkSpeed;

	public float crchSpeed;

	public float runSpeed;

	private CharacterMotor chMotor;

	private Transform tr;

	private float dist;

	public crouch_0020and_0020run()
	{
		walkSpeed = 7f;
		crchSpeed = 3f;
		runSpeed = 20f;
	}

	public virtual void Start()
	{
		chMotor = (CharacterMotor)GetComponent(typeof(CharacterMotor));
		tr = transform;
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		dist = characterController.height / 2f;
	}

	public virtual void Update()
	{
		float to = 1f;
		float maxForwardSpeed = walkSpeed;
		if ((chMotor.grounded && Input.GetKey("left shift")) || Input.GetKey("right shift"))
		{
			maxForwardSpeed = runSpeed;
		}
		if (Input.GetKey("c"))
		{
			to = 0.5f;
			maxForwardSpeed = crchSpeed;
		}
		chMotor.movement.maxForwardSpeed = maxForwardSpeed;
		float y = tr.localScale.y;
		float y2 = Mathf.Lerp(tr.localScale.y, to, 5f * Time.deltaTime);
		Vector3 localScale = tr.localScale;
		float num = (localScale.y = y2);
		Vector3 vector = (tr.localScale = localScale);
		float y3 = tr.position.y + dist * (tr.localScale.y - y);
		Vector3 position = tr.position;
		float num2 = (position.y = y3);
		Vector3 vector3 = (tr.position = position);
	}

	public virtual void Main()
	{
	}
}
