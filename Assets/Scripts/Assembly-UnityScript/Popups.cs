using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Popups : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024Spawn_00248 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024randomPick_00249;

			internal Transform _0024location_002410;

			internal Transform _0024thingToMake_002411;

			internal Popups _0024self__002412;

			public _0024(Popups self_)
			{
				_0024self__002412 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002412.spawning = true;
					_0024self__002412.timer = 0f;
					_0024randomPick_00249 = Mathf.Abs(UnityEngine.Random.Range(1, 7));
					_0024location_002410 = null;
					if (_0024randomPick_00249 == 1)
					{
						_0024location_002410 = _0024self__002412.spawn1;
						result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					if (_0024randomPick_00249 == 2)
					{
						result = (Yield(3, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					if (_0024randomPick_00249 == 3)
					{
						result = (Yield(4, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					if (_0024randomPick_00249 == 4)
					{
						result = (Yield(5, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					if (_0024randomPick_00249 == 5)
					{
						result = (Yield(6, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					if (_0024randomPick_00249 == 6)
					{
						result = (Yield(7, new WaitForSeconds(UnityEngine.Random.Range(30, 200))) ? 1 : 0);
						break;
					}
					goto IL_0218;
				case 2:
					Debug.Log("Chose pos 1");
					goto IL_0218;
				case 3:
					_0024location_002410 = _0024self__002412.spawn2;
					Debug.Log("Chose pos 2");
					goto IL_0218;
				case 4:
					_0024location_002410 = _0024self__002412.spawn3;
					Debug.Log("Chose pos 3");
					goto IL_0218;
				case 5:
					_0024location_002410 = _0024self__002412.spawn4;
					Debug.Log("Chose pos 4");
					goto IL_0218;
				case 6:
					_0024location_002410 = _0024self__002412.spawn5;
					Debug.Log("Chose pos 5");
					goto IL_0218;
				case 7:
					_0024location_002410 = _0024self__002412.spawn6;
					Debug.Log("Chose pos 6");
					goto IL_0218;
				case 8:
					_0024self__002412.spawning = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0218:
					_0024thingToMake_002411 = (Transform)Network.Instantiate(_0024location_002410, _0024self__002412.spawnpoint.position, _0024self__002412.spawnpoint.rotation, 1);
					result = (Yield(8, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Popups _0024self__002413;

		public _0024Spawn_00248(Popups self_)
		{
			_0024self__002413 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002413);
		}
	}

	public float timer;

	public bool spawning;

	public Transform spawnpoint;

	public Transform spawn1;

	public Transform spawn2;

	public Transform spawn3;

	public Transform spawn4;

	public Transform spawn5;

	public Transform spawn6;

	public virtual void Update()
	{
		if (!spawning)
		{
			timer += Time.deltaTime;
		}
		if (!(timer < 2f))
		{
			StartCoroutine_Auto(Spawn());
		}
	}

	public virtual IEnumerator Spawn()
	{
		return new _0024Spawn_00248(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
