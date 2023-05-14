//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

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
