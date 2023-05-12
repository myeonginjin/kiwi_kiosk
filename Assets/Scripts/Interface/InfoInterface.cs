using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInterface : MonoBehaviour
{
    InfoService infoService;

    void Awake()
    {
        infoService = GetComponent<InfoService>();
    }

    public void UpdateInfo(ItemData itemData)
    {
        infoService.UpdateInfo(itemData);
    }
}
