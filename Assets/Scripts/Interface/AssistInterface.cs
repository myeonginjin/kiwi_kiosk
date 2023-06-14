using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AssistInterface : MonoBehaviour
{
    AssistService assistService;
    IEnumerator voiceCoroutine;

    void Awake()
    {
        assistService = GetComponent<AssistService>();
    }

    void Start()
    {
        StartAssist();
    }

    void StartAssist()
    {
        assistService.PlayVoice(0);
    }

    public void PlayVoice(int number)
    {
        assistService.PlayVoice(number);
    }

    public void PlayWrongVoice(int number)
    {
        if (voiceCoroutine != null)
            StopCoroutine(voiceCoroutine);

        voiceCoroutine = assistService.PlayWrongVoice(number);
        StartCoroutine(voiceCoroutine);
    }

    public void ReadyBurger()
    {

    }

    public void DoneBurger()
    {

    }
}
