using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    public BridgeManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.BreakBridge();
        }
    }
}