using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager manager = other.GetComponent<CheckpointManager>();
            if (manager != null)
            {
                manager.PassedCheckpoint(checkpointIndex);
            }
        }
    }
}