using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInterface : MonoBehaviour
{
    OrderService orderService;

    void Awake()
    {
        orderService = GetComponent<OrderService>();
    }

    public void ReadyOrderNum(int num)
    {
        orderService.ReadyOrderNum(num);
    }

    public void MoveCustomer(bool isTakeOut)
    {
        StartCoroutine(orderService.MoveCustomer(isTakeOut));
    }
}
