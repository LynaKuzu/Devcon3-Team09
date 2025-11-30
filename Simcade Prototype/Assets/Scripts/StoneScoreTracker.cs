using System.Collections.Generic;
using UnityEngine;

public class StoneScoreTracker : MonoBehaviour
{
    public int currentZonePoints = 0;

    private Rigidbody rb;
    private List<int> overlappingZones = new List<int>();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called when stone enters a scoring sphere
    public void EnterZone(int points)
    {
        if (!overlappingZones.Contains(points))
            overlappingZones.Add(points);

        UpdateZoneScore();
    }

    // Called when stone exits a scoring sphere
    public void ExitZone(int points)
    {
        if (overlappingZones.Contains(points))
            overlappingZones.Remove(points);

        UpdateZoneScore();
    }

    void UpdateZoneScore()
    {
        if (overlappingZones.Count > 0)
            currentZonePoints = Mathf.Max(overlappingZones.ToArray());
        else
            currentZonePoints = 0;

        // Update UI instantly
        ScoreUI.instance?.SetScore(currentZonePoints);
    }
}