//참여
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayInterface : MonoBehaviour
{
    PayService payService;
    bool isPaid = false;

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

    public void ShowOrderNumber()
    {
        if (!isPaid)
        {
            isPaid = true;
            StartCoroutine(payService.ShowOrderNumber());
        }
    }
}
