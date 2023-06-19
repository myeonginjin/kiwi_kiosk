//참여
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class POSService : MonoBehaviour
{
    public GameObject parent;
    public GameObject nextStep;
    public UnityEvent onComplete;
    public bool isInserted = false;

    AudioSource beep;

    void Awake()
    {
        beep = GetComponent<AudioSource>();
    }

    public IEnumerator InsertCard()
    {
        isInserted = true;
        beep.Play();

        yield return new WaitForSeconds(2);

        nextStep.SetActive(true);
        parent.SetActive(false);
        onComplete.Invoke();
        isInserted = false;
    }
}
