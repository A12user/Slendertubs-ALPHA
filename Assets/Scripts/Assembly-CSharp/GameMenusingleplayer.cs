using UnityEngine;

public class GameMenusingleplayer : MonoBehaviour
{
	public GameObject PlayerPrefab;

	public GameObject TinkyPrefab;

	private string ip = "127.0.0.1";

	private bool connected;

	public void Awake()
	{
		Application.runInBackground = true;
	}

	public void CreatePlayer()
	{
		connected = true;
		GameObject gameObject = (GameObject)Network.Instantiate(PlayerPrefab, base.transform.position, base.transform.rotation, 1);
		gameObject.networkView.stateSynchronization = NetworkStateSynchronization.Unreliable;
		gameObject.transform.Find("Camera").GetComponent<Camera>().enabled = true;
		base.camera.enabled = false;
	}

	private void OnDisconnectedFromServer()
	{
		connected = false;
	}

	private void OnPlayerDisconnected(NetworkPlayer pl)
	{
		Network.DestroyPlayerObjects(pl);
	}

	private void OnServerInitialized()
	{
		CreatePlayer();
	}

	private void OnGUI()
	{
		if (!connected && GUILayout.Button("Start"))
		{
			Network.InitializeServer(10, 5300, false);
		}
	}

	private void Start()
	{
		Network.InitializeServer(10, 5300, false);
	}
}
