//참여
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayInterface : MonoBehaviour
{
    PayService payService;

    void Awake()
    {
        payService = GetComponent<PayService>();
    }

    public void ShowPayList(CartData cartData)
    {
        payService.ShowPayList(cartData);
    }

    public void ClearPayList()
    {
        payService.ClearPayList();
    }

    public void UpdateTakeOut(bool isOn)
    {
        payService.UpdateTakeOut(isOn);
    }

    public void ShowOrderNumber()
    {
        payService.ShowOrderNumber();
    }
}
