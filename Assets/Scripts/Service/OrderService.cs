//참여
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class OrderService : MonoBehaviour
{
    public TextMeshProUGUI readyTMPro;
    public TextMeshProUGUI doneTMPro;
    public UnityEvent onMove;

    OrderData orderData;

    void Awake()
    {
        orderData = GetComponent<OrderData>();
    }

    public void ReadyOrderNum(PayData payData)
    {
        readyTMPro.text = payData.orderNumber.ToString();
    }
    
    public void ReadyOrderNum(int orderNumber)
    {
        readyTMPro.text = orderNumber.ToString();
    }

    public IEnumerator MoveCustomer(bool isTakeOut)
    {
        yield return new WaitForSeconds(5);

        CompleteOrderNum();
        PutItem(isTakeOut);

        float moveRate = 0f;
        Vector3 startPosition = orderData.customer.transform.position;

        while (moveRate < 1f)
        {
            moveRate += Time.deltaTime * 0.7f;
            orderData.customer.transform.position = Vector3.Lerp(
                startPosition, orderData.customerDest.position, moveRate);

            yield return new WaitForEndOfFrame();
        }

        onMove.Invoke();
    }

    void CompleteOrderNum()
    {
        doneTMPro.text = readyTMPro.text;
        readyTMPro.text = "";
    }

    void PutItem(bool isTakeOut)
    {
        if (isTakeOut)
            Instantiate(orderData.bagPrefab, orderData.itemPos);
        else
            Instantiate(orderData.burgerPrefab, orderData.itemPos);
    }
}
