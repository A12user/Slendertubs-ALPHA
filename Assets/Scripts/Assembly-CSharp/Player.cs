using UnityEngine;

public class Player : MonoBehaviour
{
	private void Start()
	{
		if (!base.networkView.isMine)
		{
			Object.Destroy(GetComponent<FPSInputController>());
			Object.Destroy(GetComponent<CharacterMotor>());
			Object.Destroy(GetComponent<CharacterController>());
			Object.Destroy(GetComponent<MouseLook>());
		}
	}
}
