using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneReset : MonoBehaviour
{
    [field: SerializeField] public Rigidbody StoneRB { get; private set; }
    [field: SerializeField] public KeyCode ResetKey { get; private set; } = KeyCode.R;

    private Vector3 position;
    private Quaternion orientation;

    public StoneMove stonemove;

    private void Awake()
    {
        if (StoneRB == null)
        {
            string msg = $"Missing Component {nameof(Rigidbody)} {nameof(StoneRB)}.";
            throw new MissingComponentException(msg);
        }

        position = transform.position;
        orientation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(ResetKey))
        {
            stonemove.HasShot = false;
            StoneRB.MovePosition(position);
            StoneRB.MoveRotation(orientation);
            stonemove.RockMove = 0;
            StoneRB.velocity = Vector3.zero;
            StoneRB.angularVelocity = Vector3.zero;
            foreach (var script in FindObjectsByType<StoneDebug>(FindObjectsSortMode.None))
            {
                script.ClearDebugData();
            }
        }
    }

    private void Reset()
    {
        if (StoneRB == null)
            StoneRB = GetComponent<Rigidbody>();
    }
}
