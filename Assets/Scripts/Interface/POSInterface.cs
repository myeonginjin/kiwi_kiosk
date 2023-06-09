using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSInterface : MonoBehaviour
{
    POSService POSService;

    void Awake()
    {
        POSService = GetComponent<POSService>();
    }

    public void InsertCard()
    {
        if (!POSService.isInserted)
            StartCoroutine(POSService.InsertCard());
    }
}
