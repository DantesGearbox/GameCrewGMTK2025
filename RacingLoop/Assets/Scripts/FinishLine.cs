using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager manager = other.GetComponent<CheckpointManager>();
            if (manager != null)
            {
                manager.CrossFinishLine();
            }
        }
    }
}