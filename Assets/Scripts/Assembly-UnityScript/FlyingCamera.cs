using System;
using UnityEngine;

[Serializable]
public class FlyingCamera : MonoBehaviour
{
	public float lookSpeed;

	public float moveSpeed;

	public float rotationX;

	public float rotationY;

	public FlyingCamera()
	{
		lookSpeed = 7f;
		moveSpeed = 3f;
	}

	public virtual void Update()
	{
		rotationX += Input.GetAxis("Mouse X") * lookSpeed;
		rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
		rotationY = Mathf.Clamp(rotationY, -90f, 90f);
		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
		transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical");
		transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal");
	}

	public virtual void Main()
	{
	}
}
