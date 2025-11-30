using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringZone1 : MonoBehaviour
{
    public int points;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            StoneScoreTracker tracker = other.GetComponent<StoneScoreTracker>();
            if (tracker != null)
                tracker.EnterZone(points);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            StoneScoreTracker tracker = other.GetComponent<StoneScoreTracker>();
            if (tracker != null)
                tracker.ExitZone(points);
        }
    }
}
