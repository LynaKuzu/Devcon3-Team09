using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDebug : MonoBehaviour
{
    [field: SerializeField] public Rigidbody StoneRB { get; private set; }

    private const int gizmoCount = 8196;
    private List<Vector3> positions = new();
    private List<Vector3> normals = new();

    private void Awake()
    {
        if (StoneRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(StoneRB)}.";
            throw new MissingComponentException(msg);
        }

        positions = new List<Vector3>(gizmoCount);
        normals = new List<Vector3>(gizmoCount);
    }

    private void FixedUpdate()
    {
        RecordDebugData();
    }

    private void Reset()
    {
        if (StoneRB == null)
            StoneRB = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        // Draw position and facing directions
        Gizmos.color = Color.red;
        Gizmos.DrawLineStrip(positions.ToArray(), false);
        Gizmos.color = Color.white;
        Gizmos.DrawLineStrip(normals.ToArray(), false);

        // Display axes of motion
        float velocityMagnitude = StoneRB.velocity.magnitude;
        Vector3 velocityDirection = StoneRB.velocity.normalized;
        Vector3 axisOfRotation = StoneRB.angularVelocity.normalized;
        // Only render if significant forces exist
        if (velocityMagnitude < 0.01f)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + velocityDirection * 10);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + axisOfRotation * 10);
    }

    private void RecordDebugData()
    {
        // Only render if significant forces exist
        float velocityMagnitude = StoneRB.velocity.magnitude;
        if (velocityMagnitude < 0.01f)
            return;

        // Clear old data when at limit
        if (positions.Count >= gizmoCount)
        {
            positions.RemoveAt(0);
            normals.RemoveAt(0);
        }
        // Add new data
        positions.Add(transform.position);
        normals.Add(transform.position + transform.forward);
    }

    public void ClearDebugData()
    {
        positions.Clear();
        normals.Clear();
    }
}

