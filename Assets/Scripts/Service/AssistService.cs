using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssistService : MonoBehaviour
{
    AssistData assistData;
    AudioSource audioSource;

    public bool isBeep = false;

    void Awake()
    {
        assistData = GetComponent<AssistData>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayVoice(int number)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = assistData.voiceList[number];
        audioSource.Play();
    }

    public IEnumerator PlayWrongVoice(int number)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = assistData.wrongVoice;
        audioSource.Play();

        yield return new WaitForSeconds(2);

        if (!audioSource.isPlaying)
            PlayVoice(number);
    }
}
