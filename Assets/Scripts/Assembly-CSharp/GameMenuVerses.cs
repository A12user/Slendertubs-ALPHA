using UnityEngine;

public class GameMenuVerses : MonoBehaviour
{
	public GameObject PlayerPrefab;

	public GameObject TinkyPrefab;

	public GameObject NoFog;

	public GameObject TinkySpawn;

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

	public void CreateTinkyPlayer()
	{
		connected = true;
		GameObject gameObject = (GameObject)Network.Instantiate(TinkyPrefab, TinkySpawn.transform.position, TinkySpawn.transform.rotation, 1);
		gameObject.networkView.stateSynchronization = NetworkStateSynchronization.Unreliable;
		gameObject.transform.Find("Camera").GetComponent<Camera>().enabled = true;
		gameObject.transform.Find("Camera").GetComponent<Light>().enabled = true;
		base.camera.enabled = false;
		Object.Instantiate(NoFog, base.transform.position, base.transform.rotation);
	}

	private void OnDisconnectedFromServer()
	{
		connected = false;
	}

	private void OnPlayerDisconnected(NetworkPlayer pl)
	{
		Network.DestroyPlayerObjects(pl);
	}

	private void OnConnectedToServer()
	{
		CreatePlayer();
	}

	private void OnServerInitialized()
	{
		CreateTinkyPlayer();
	}

	private void OnGUI()
	{
		if (!connected)
		{
			ip = GUILayout.TextField(ip);
			if (GUILayout.Button("Connect as Victim"))
			{
				Network.Connect(ip, 5300);
			}
			if (GUILayout.Button("Host as Slendytubby"))
			{
				Network.InitializeServer(10, 5300, false);
			}
		}
	}
}
