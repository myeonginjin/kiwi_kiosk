//참여
//2017012488_컴퓨터학부_이현준

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
