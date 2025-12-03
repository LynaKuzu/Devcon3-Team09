using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;

    [SerializeField] private TMP_Text scoreText;
    private int displayedScore = 0;
    private Coroutine animRoutine;

    private void Awake()
    {
        instance = this;
    }

    public void SetScore(int newScore)
    {
        if (animRoutine != null)
            StopCoroutine(animRoutine);

        animRoutine = StartCoroutine(AnimateScore(displayedScore, newScore));
    }

    private System.Collections.IEnumerator AnimateScore(int start, int end)
    {
        float t = 0f;
        float duration = 0.4f;

        scoreText.transform.localScale = Vector3.one * 1.3f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float n = Mathf.SmoothStep(0f, 1f, t / duration);

            displayedScore = Mathf.RoundToInt(Mathf.Lerp(start, end, n));
            scoreText.text = "Score: " + displayedScore;

            float scale = Mathf.Lerp(2.6f, 3f, n);
            scoreText.transform.localScale = Vector3.one * scale;

            yield return null;
        }

        displayedScore = end;
        scoreText.text = "Score: " + displayedScore;
        scoreText.transform.localScale = Vector3.one;
    }
}