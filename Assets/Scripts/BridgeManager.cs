using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public FixedJoint[] allJoints;
    public float scatterForce = 10f;
    private bool alreadyBroken = false;

    public void BreakBridge()
    {
        if (alreadyBroken) return;
        alreadyBroken = true;

        foreach (FixedJoint joint in allJoints)
        {
            if (joint == null) continue;

            Rigidbody rb = joint.GetComponent<Rigidbody>();
            Destroy(joint);

            if (rb != null)
            {
                Vector3 dir = new Vector3(Random.Range(-1f, 1f), -0.5f, Random.Range(-1f, 1f));
                rb.AddForce(dir * scatterForce, ForceMode.Impulse);
            }
        }
    }
}