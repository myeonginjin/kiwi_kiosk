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

    public void InitSetPopup(ItemData itemData)
    {
        infoService.InitSetPopup(itemData);
    }

    public void InitOptionPopup()
    {
        infoService.InitOptionPopup();
    }

    public void UpdateSideData()
    {
        infoService.UpdateSideData();
    }

    public void UpdateDrinkData()
    {
        infoService.UpdateDrinkData();
    }
}