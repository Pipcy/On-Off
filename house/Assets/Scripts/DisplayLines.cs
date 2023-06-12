using System.Collections;
using TMPro;
using UnityEngine;

public class DisplayLines : MonoBehaviour
{
    public TextMeshProUGUI[] lines;
    public float fadeInDuration = 1f;
    public float fadeOutDuration = 1f;
    public float lineDelay = 1f;

    private void Start()
    {
        foreach(TextMeshProUGUI line in lines)
        {
            line.enabled = false;
        }
        StartCoroutine(DisplayLinesCoroutine());
    }

    private IEnumerator DisplayLinesCoroutine()
    {
        foreach (TextMeshProUGUI line in lines)
        {
            yield return StartCoroutine(FadeIn(line));
            yield return new WaitForSeconds(lineDelay);
            yield return StartCoroutine(FadeOut(line));
        }

        // All lines have been displayed
        //gameObject.SetActive(false);
    }

    private IEnumerator FadeIn(TextMeshProUGUI text)
    {
        Color originalColor = text.color;
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        text.enabled = true;

        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, originalColor.a, elapsedTime / fadeInDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.color = originalColor;
    }

    private IEnumerator FadeOut(TextMeshProUGUI text)
    {
        Color originalColor = text.color;
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsedTime / fadeOutDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        text.enabled = false;
    }
}

