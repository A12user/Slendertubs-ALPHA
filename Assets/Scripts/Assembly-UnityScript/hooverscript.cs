using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class hooverscript : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Slow_00245 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal hooverscript _0024self__00246;

			public _0024(hooverscript self_)
			{
				_0024self__00246 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__00246.slowState)
					{
						_0024self__00246.accelState = false;
						_0024self__00246.slowState = true;
					}
					_0024self__00246.currentSpeed *= _0024self__00246.inertia;
					_0024self__00246.transform.Translate(0f, 0f, Time.deltaTime * _0024self__00246.currentSpeed);
					if (!(_0024self__00246.currentSpeed > _0024self__00246.minSpeed))
					{
						_0024self__00246.currentSpeed = 0f;
						result = (Yield(2, new WaitForSeconds(_0024self__00246.stopTime)) ? 1 : 0);
						break;
					}
					goto IL_00d6;
				case 2:
					_0024self__00246.functionState = 0;
					goto IL_00d6;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00d6:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal hooverscript _0024self__00247;

		public _0024Slow_00245(hooverscript self_)
		{
			_0024self__00247 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__00247);
		}
	}

	public float accel;

	public float inertia;

	public float speedLimit;

	public float minSpeed;

	public float stopTime;

	private float currentSpeed;

	private int functionState;

	private bool accelState;

	private bool slowState;

	private Transform waypoint;

	public float rotationDamping;

	public bool smoothRotation;

	public Transform[] waypoints;

	private int WPindexPointer;

	public hooverscript()
	{
		accel = 0.8f;
		inertia = 0.9f;
		speedLimit = 10f;
		minSpeed = 1f;
		stopTime = 1f;
		rotationDamping = 6f;
		smoothRotation = true;
	}

	public virtual void Start()
	{
		functionState = 0;
	}

	public virtual void Update()
	{
		if (functionState == 0)
		{
			Accell();
		}
		if (functionState == 1)
		{
			StartCoroutine_Auto(Slow());
		}
		waypoint = waypoints[WPindexPointer];
	}

	public virtual void Accell()
	{
		if (!accelState)
		{
			accelState = true;
			slowState = false;
		}
		if ((bool)waypoint && smoothRotation)
		{
			Quaternion to = Quaternion.LookRotation(waypoint.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * rotationDamping);
		}
		currentSpeed += accel * accel;
		transform.Translate(0f, 0f, Time.deltaTime * currentSpeed);
		if (!(currentSpeed < speedLimit))
		{
			currentSpeed = speedLimit;
		}
	}

	public virtual void OnTriggerEnter()
	{
		functionState = 1;
		WPindexPointer++;
		if (WPindexPointer >= waypoints.Length)
		{
			WPindexPointer = 0;
		}
	}

	public virtual IEnumerator Slow()
	{
		return new _0024Slow_00245(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
