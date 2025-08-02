using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public int totalCheckpoints = 5;
    public int currentCheckpointIndex = 0;
    public int currentLap = 0;
    public int totalLaps = 5;
    private bool lapCompleted = false;

    public GhostSpawner ghostSpawner;

	public void ResetCheckpoints()
    {
        currentCheckpointIndex = 0;
    }

    public void PassedCheckpoint(int checkpointIndex)
    {
        if (checkpointIndex == currentCheckpointIndex)
        {
            currentCheckpointIndex++;

            if (currentCheckpointIndex == totalCheckpoints)
            {
                lapCompleted = true;
                currentCheckpointIndex = 0;
            }
        }
    }

    public void CrossFinishLine()
    {
        if (lapCompleted)
        {
            currentLap++;
            lapCompleted = false;

            Debug.Log("Lap Completed! Current Lap: " + currentLap);

            ghostSpawner.SpawnGhost();

            if (currentLap >= totalLaps)
            {
                Debug.Log("Race Finished!");
                // Implement win logic here
            }
        }
    }
}