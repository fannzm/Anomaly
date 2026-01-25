using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct SubtitleLine
{
    public string text;
    public float startTime;
}

public class TutorialVoice : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshProUGUI subtitleText;
    public List<SubtitleLine> lines;

    void Awake()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            StartCoroutine(PlaySubtitles());
        }
    }

    IEnumerator PlaySubtitles()
    {
        foreach (var line in lines)
        {
            yield return new WaitUntil(() => audioSource.time >= line.startTime);
            subtitleText.text = line.text;
        }

        yield return new WaitUntil(() => !audioSource.isPlaying);
        subtitleText.text = "";
    }
}