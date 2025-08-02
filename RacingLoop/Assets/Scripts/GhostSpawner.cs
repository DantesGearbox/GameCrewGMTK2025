using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
	public GameObject ghostPrefab;
	public InputRecorder playerInputRecorder;

	void SpawnGhost()
	{
		GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);
		InputReplayer replayer = ghost.GetComponent<InputReplayer>();
		replayer.SetReplayData(playerInputRecorder.GetRecordedData());
	}

	private void Update()
	{
		if (playerInputRecorder != null)
		{
			if(Input.GetKeyDown(KeyCode.L))
			{
				SpawnGhost();
			}
		}
	}
}
