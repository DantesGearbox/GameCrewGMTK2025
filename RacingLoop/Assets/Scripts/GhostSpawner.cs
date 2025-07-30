// Spawns ghost after player finishes lap or after delay

using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
	public GameObject ghostPrefab;
	public InputRecorder playerRecorder;

	void SpawnGhost()
	{
		GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);
		InputReplayer replayer = ghost.GetComponent<InputReplayer>();
		replayer.SetReplayData(playerRecorder.GetRecordedData());
	}

	private void Update()
	{
		if (playerRecorder != null)
		{
			if(Input.GetKeyDown(KeyCode.L))
			{
				SpawnGhost();
			}
		}
	}
}
